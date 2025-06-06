import React, { useState, useEffect, useRef } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { ABILITIES, ABILITY_SHORT_NAMES, calculateModifier } from '../../data/abilityScoresData';

import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

const CharacterCreationSummary = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [charData, setCharData] = useState(null);
  const portraitRef = useRef(null);
  const [cameFromManagement, setCameFromManagement] = useState(false);

   const generatePdf = async () => {
    if (!charData) return;

     const addSingleLineText = (text, x, y, options = {}) => {
      if (y > pageHeight - margin - (options.lineHeight || lineHeight)) {
        pdf.addPage();
        y = margin;
      }
      pdf.text(text, x, y, options);
      return y + (options.lineHeight || lineHeight);
    };

    const pdf = new jsPDF('p', 'pt', 'a4');
    let yPos = 40;
    const pageHeight = pdf.internal.pageSize.getHeight();
    const pageWidth = pdf.internal.pageSize.getWidth();
    const margin = 40;
    const lineHeight = 18;
    const sectionSpacing = 25;
    const contentWidth = pageWidth - 2 * margin;

    const addText = (text, x, y, options = {}) => {
      if (y > pageHeight - margin - lineHeight) {
        pdf.addPage();
        y = margin;
      }
      pdf.text(text, x, y, options);
      return y + (options.lineHeightOffset || lineHeight);
    };

    pdf.setFontSize(18);
    pdf.setFont('helvetica', 'bold');
    yPos = addText(`Character Sheet: ${charData.name || 'Unnamed Character'}`, margin, yPos);
    yPos += 10;

    pdf.setFontSize(12);
    pdf.setFont('helvetica', 'normal');

    if (charData.avatar && portraitRef.current) {
      try {
        const canvas = await html2canvas(portraitRef.current, {
          useCORS: true,
          scale: 2,
        });
        const imgData = canvas.toDataURL('image/png');
        const imgProps = pdf.getImageProperties(imgData);
        const pdfImgWidth = 100;
        const pdfImgHeight = (imgProps.height * pdfImgWidth) / imgProps.width;
        
        if (yPos + pdfImgHeight > pageHeight - margin) {
            pdf.addPage();
            yPos = margin;
        }
        pdf.addImage(imgData, 'PNG', margin, yPos, pdfImgWidth, pdfImgHeight);
        yPos += pdfImgHeight + 10;
      } catch (error) {
        console.error("Error capturing avatar for PDF:", error);
        yPos = addText("(Avatar could not be rendered)", margin, yPos);
      }
    }


    const addSection = (title, contentCallback) => {
      if (yPos > pageHeight - margin - sectionSpacing * 1.5) {
          pdf.addPage(); yPos = margin;
      }
      pdf.setFontSize(14);
      pdf.setFont('helvetica', 'bold');
      yPos = addSingleLineText(title, margin, yPos, {lineHeight: 20});
      pdf.setFontSize(10);
      pdf.setFont('helvetica', 'normal');
      yPos = contentCallback(yPos);
      yPos += sectionSpacing / 2;
      return yPos;
    };
    
    const addKeyValuePair = (currentY, label, value, indent = 0) => {
        const fullLabel = label + ": ";
        const labelWidth = pdf.getStringUnitWidth(fullLabel) * pdf.getFontSize() / pdf.internal.scaleFactor;
        const availableValueWidth = contentWidth - labelWidth - indent;

        const lines = pdf.splitTextToSize(String(value || 'N/A'), availableValueWidth > 0 ? availableValueWidth : contentWidth - indent - 20);

        lines.forEach((line, index) => {
            let textToPrint = "";
            let xPos = margin + indent;
            if (index === 0) {
                textToPrint = fullLabel + line;
            } else {
                textToPrint = line;
                xPos += labelWidth + 5;
            }
             if (currentY > pageHeight - margin - 14) { pdf.addPage(); currentY = margin; }
            pdf.text(textToPrint, xPos, currentY);
            currentY += 14;
        });
        return currentY;
    };


    yPos = addSection("Basic Information", (currentY) => {
      currentY = addKeyValuePair(currentY, "Name", charData.name);
      currentY = addKeyValuePair(currentY, "Alignment", charData.alignment);
      currentY = addKeyValuePair(currentY, "Gender", charData.gender);
      currentY = addKeyValuePair(currentY, "Age", charData.age);
      currentY = addKeyValuePair(currentY, "Weight", charData.weight);
      currentY = addKeyValuePair(currentY, "Height", charData.height);
      pdf.setFont('helvetica', 'bold');
      currentY = addText("Appearance:", margin, currentY, {lineHeightOffset: 14});
      pdf.setFont('helvetica', 'normal');
      const appearanceLines = pdf.splitTextToSize(charData.appearance || "No description.", contentWidth - 10);
      appearanceLines.forEach(line => currentY = addText(line, margin + 10, currentY, {lineHeightOffset: 14}));
      return currentY;
    });

    yPos = addSection("Personality", (currentY) => {
        currentY = addKeyValuePair(currentY, "Ideals", charData.story?.ideals);
        currentY = addKeyValuePair(currentY, "Bonds", charData.story?.bonds);
        currentY = addKeyValuePair(currentY, "Flaws", charData.story?.flaws);
        return currentY;
    });
    
    yPos = addSection("Personality", (currentY) => {
        currentY = addKeyValuePair(currentY, "Ideals", charData.story?.ideals);
        currentY = addKeyValuePair(currentY, "Bonds", charData.story?.bonds);
        currentY = addKeyValuePair(currentY, "Flaws", charData.story?.flaws);
        return currentY;
    });

    const constitutionModifier = charData.abilityScores?.modifiers?.con || 0;
    let hitPoints = 0;
    if (charData.classDetailsForHP?.hitPoints?.hpAt1stLevel) {
      const hpString = charData.classDetailsForHP.hitPoints.hpAt1stLevel;
      const baseHpMatch = hpString.match(/^(\d+)\s*\+/);
      hitPoints = baseHpMatch ? parseInt(baseHpMatch[1]) + constitutionModifier : 8 + constitutionModifier;
    } else {
        hitPoints = 8 + constitutionModifier;
    }

    yPos = addSection("Combat & Stats", (currentY) => {
      currentY = addKeyValuePair(currentY, "Hit Points (HP)", hitPoints);
      currentY = addKeyValuePair(currentY, "Saving Throws", charData.proficiencies?.savingThrows);
      currentY += 10;

      pdf.setFont('helvetica', 'bold');
      const tableHeaderY = currentY;
      const cellHeight = 22;
      const headerCellHeight = 25;
      const colWidths = [120, 90, 90];
      const tableRightX = margin + colWidths.reduce((a, b) => a + b);

      if (tableHeaderY + headerCellHeight > pageHeight - margin) {
          pdf.addPage(); currentY = margin;
      } else {
          currentY = tableHeaderY;
      }
      
      let cellX = margin;
      pdf.text("Attribute", cellX + 5, currentY + 15);
      cellX += colWidths[0];
      pdf.text("Total Score", cellX + (colWidths[1] / 2) - (pdf.getStringUnitWidth("Total Score") * pdf.getFontSize() / 2), currentY + 15);
      cellX += colWidths[1];
      pdf.text("Modifier", cellX + (colWidths[2] / 2) - (pdf.getStringUnitWidth("Modifier") * pdf.getFontSize() / 2), currentY + 15);
      
      currentY += headerCellHeight;

      pdf.setLineWidth(1);
      pdf.line(margin, currentY, tableRightX, currentY);
      pdf.setLineWidth(0.5);

      pdf.setFont('helvetica', 'normal');
      (charData.abilityScores && ABILITIES || []).forEach(ability => {
        if (currentY + cellHeight > pageHeight - margin) {
          pdf.addPage();
          currentY = margin;
        }
        
        const textY = currentY + (cellHeight / 2) + (pdf.getFontSize() / 3);
        const key = ABILITY_SHORT_NAMES[ability];
        cellX = margin;

        pdf.text(ability, cellX + 5, textY);
        cellX += colWidths[0];

        const scoreStr = String(charData.abilityScores.total[key]);
        pdf.text(scoreStr, cellX + (colWidths[1] / 2) - (pdf.getStringUnitWidth(scoreStr) * pdf.getFontSize() / 2), textY);
        cellX += colWidths[1];

        const modStr = String(charData.abilityScores.modifiers[key]);
        pdf.text(modStr, cellX + (colWidths[2] / 2) - (pdf.getStringUnitWidth(modStr) * pdf.getFontSize() / 2), textY);
        
        currentY += cellHeight;
        pdf.line(margin, currentY, tableRightX, currentY);
      });

      return currentY;
    });

    const displaySkills = charData.finalSkillProficiencies?.join(', ') || 'None';
    const displayArmorProf = mergeProficiencies(charData.proficiencies?.armor);
    const displayWeaponProf = mergeProficiencies(charData.proficiencies?.weapons);
    const displayToolProf = mergeProficiencies(charData.proficiencies?.tools, charData.backgroundToolProficiencies);

    yPos = addSection("Proficiencies", (currentY) => {
      currentY = addKeyValuePair(currentY, "Skills", displaySkills);
      currentY = addKeyValuePair(currentY, "Armor", displayArmorProf);
      currentY = addKeyValuePair(currentY, "Weapons", displayWeaponProf);
      currentY = addKeyValuePair(currentY, "Tools", displayToolProf);
      return currentY;
    });
    
    yPos = addSection("Equipment", (currentY) => {
      const equipmentItems = [];
      (charData.equipmentChosen || []).forEach(item => equipmentItems.push(item));
      if (charData.backgroundEquipment) {
        equipmentItems.push(`${charData.backgroundEquipment} (from background)`);
      }

      if (equipmentItems.length === 0) {
        currentY = addSingleLineText("- None", margin + 10, currentY, {lineHeight: 14});
      } else {
        equipmentItems.forEach(item => {
          const itemLines = pdf.splitTextToSize(`- ${item}`, contentWidth - 10);
          itemLines.forEach(line => {
            currentY = addSingleLineText(line, margin + 10, currentY, {lineHeight: 14});
          });
        });
      }
      return currentY;
    });

    pdf.save(`${charData.name || 'Character'}_Sheet.pdf`);
  };

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';
    document.body.style.backgroundPosition = 'center';
    document.body.style.backgroundRepeat = 'no-repeat';
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.minHeight = '100vh';

    if (location.state) {
      setCharData(location.state.finalCharData);
      if (location.state.cameFromManagement) {
        setCameFromManagement(true);
      }
    } else {
      navigate('/character-creation/step6');
    }
  }, [location.state, navigate]);

  const handleViewDevelopmentTree = () => {
    if (charData) {
      navigate('/character-development-tree', {
        state: {
          charDataForTree: charData,
          cameFromManagement: cameFromManagement
        }
      });
    }
  };

  const handleGoBackToManagement = () => {
    navigate('/character-management');
  };

  const handleGoBackToCreationFlow = () => {
    navigate('/character-creation/step6', { state: { charData: charData } });
  };

  const handleCreateCharacter = () => {
    if (!charData) return;
    const characterToSave = {
      ...charData,
      id: charData.id || `char_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`,
      createdAt: new Date().toISOString(),
    };

    const existingCharacters = JSON.parse(localStorage.getItem('skuffrollCharacters') || '[]');

    existingCharacters.push(characterToSave);

    localStorage.setItem('skuffrollCharacters', JSON.stringify(existingCharacters));

    saveCharacterToBackend();
    navigate('/character-management');
  };

  if (!charData) {
    return <div className="character-creation-page"><p>Loading character summary...</p></div>;
  }

  const mergeProficiencies = (...proficiencySources) => {
    const allItems = [];
    proficiencySources.forEach(source => {
      if (typeof source === 'string') {
        source.split(',').forEach(item => {
          const trimmedItem = item.trim();
          if (trimmedItem && trimmedItem.toLowerCase() !== 'none') {
            allItems.push(trimmedItem);
          }
        });
      } else if (Array.isArray(source)) {
        source.forEach(item => {
          if (typeof item === 'string') {
            const trimmedItem = item.trim();
            if (trimmedItem && trimmedItem.toLowerCase() !== 'none') {
              allItems.push(trimmedItem);
            }
          }
        });
      }
    });
    const uniqueItems = [...new Set(allItems.map(item => item.toLowerCase()))]
                        .map(lowerItem => allItems.find(item => item.toLowerCase() === lowerItem));
    return uniqueItems.length > 0 ? uniqueItems.join(', ') : 'None';
  };


  if (!charData) {
    return <div className="character-creation-page"><p>Loading character summary...</p></div>;
  }


  const constitutionModifier = charData.abilityScores?.modifiers?.con || 0;
  let hitPoints = 0;
  if (charData.className && charData.classDetailsForHP?.hitPoints?.hpAt1stLevel) {
      const hpString = charData.classDetailsForHP.hitPoints.hpAt1stLevel;
      const baseHpMatch = hpString.match(/^(\d+)\s*\+/);
      if (baseHpMatch) {
          hitPoints = parseInt(baseHpMatch[1]) + constitutionModifier;
      } else {
          hitPoints = 8 + constitutionModifier;
      }
  } else {
      hitPoints = 8 + constitutionModifier;
  }

  const displaySkills = charData.finalSkillProficiencies && charData.finalSkillProficiencies.length > 0
                        ? charData.finalSkillProficiencies.join(', ')
                        : 'None';

  const displayArmorProf = mergeProficiencies(charData.proficiencies?.armor);
  const displayWeaponProf = mergeProficiencies(charData.proficiencies?.weapons);

  const displayToolProf = mergeProficiencies(
    charData.proficiencies?.tools,
    charData.backgroundToolProficiencies
    );

    const currentUser = sessionStorage.getItem('currentUser'); 
    const parsedUser = JSON.parse(currentUser);

    const charDataWithLogin = {
        char: charData,
        login: parsedUser.login,
    };

    const saveCharacterToBackend = async () => {
        try {
            const response = await fetch("/api/character/create", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(charDataWithLogin),
            });

            if (!response.ok) {
                const error = await response.text();
                throw new Error(`Server error: ${error}`);
            }

            const result = await response.json();
            return result.characterId;
        } catch (err) {
            console.error("Error saving character:", err);
            throw err;
        }
    };


  return (
    <main className="character-creation-page character-summary-page">
      <div className="summary-layout">
        <div className="summary-portrait-section">
          {charData.avatar ? (
            <img ref={portraitRef} src={charData.avatar} alt={`${charData.name}'s Avatar`} className="summary-avatar-image" crossOrigin="anonymous" />
          ) : (
            <div ref={portraitRef} className="placeholder-avatar">No Avatar</div>
          )}
          <button onClick={generatePdf} className="char-nav-button" style={{backgroundColor: '#4CAF50', borderColor: '#388E3C', marginTop: '10px', width: '100%', maxWidth: '200px'}}>
            Export to PDF
          </button>
          <button
            onClick={handleViewDevelopmentTree}
            className="char-nav-button"
            style={{backgroundColor: '#007BFF', borderColor: '#0056b3', marginTop: '10px', width: '100%', maxWidth: '200px'}}
          >
            Development Tree
          </button>
        </div>

        <div className="summary-main-details">
          <div className="summary-block">
            <h3>Basic Information</h3>
            <div className="summary-item"><span className="summary-item-label">Name:</span> <span className="summary-item-value">{charData.name}</span></div>
            <div className="summary-item"><span className="summary-item-label">Alignment:</span> <span className="summary-item-value">{charData.alignment}</span></div>
            <div className="summary-item"><span className="summary-item-label">Gender:</span> <span className="summary-item-value">{charData.gender || 'N/A'}</span></div>
            <div className="summary-item"><span className="summary-item-label">Age:</span> <span className="summary-item-value">{charData.age || 'N/A'}</span></div>
            <div className="summary-item"><span className="summary-item-label">Weight:</span> <span className="summary-item-value">{charData.weight || 'N/A'}</span></div>
            <div className="summary-item"><span className="summary-item-label">Height:</span> <span className="summary-item-value">{charData.height || 'N/A'}</span></div>
            <div className="summary-item"><span className="summary-item-label">Appearance:</span> <span className="summary-item-value long-text">{charData.appearance || 'No description.'}</span></div>
          </div>

          <div className="summary-block">
            <h3>Class, Race & Background</h3>
            <div className="summary-item"><span className="summary-item-label">Class:</span> <span className="summary-item-value">{charData.className}</span></div>
            <div className="summary-item"><span className="summary-item-label">Race:</span> <span className="summary-item-value">{charData.raceName}</span></div>
            <div className="summary-item"><span className="summary-item-label">Background:</span> <span className="summary-item-value">{charData.backgroundName}</span></div>
          </div>

          <div className="summary-block">
            <h3>Personality</h3>
            <div className="summary-item"><span className="summary-item-label">Ideals:</span> <span className="summary-item-value long-text">{charData.story?.ideals || 'N/A'}</span></div>
            <div className="summary-item"><span className="summary-item-label">Bonds:</span> <span className="summary-item-value long-text">{charData.story?.bonds || 'N/A'}</span></div>
            <div className="summary-item"><span className="summary-item-label">Flaws:</span> <span className="summary-item-value long-text">{charData.story?.flaws || 'N/A'}</span></div>
          </div>

          <div className="summary-block">
            <h3>Ability Scores & Combat</h3>
            <div className="summary-item"><span className="summary-item-label">Hit Points (HP):</span> <span className="summary-item-value">{hitPoints}</span></div>
            <div className="summary-item"><span className="summary-item-label">Saving Throws:</span> <span className="summary-item-value">{charData.proficiencies?.savingThrows || 'N/A'}</span></div>
            <table className="summary-stats-table">
              <thead>
                <tr>
                  <th>Attribute</th>
                  <th>Total Score</th>
                  <th>Modifier</th>
                </tr>
              </thead>
              <tbody>
                {charData.abilityScores && ABILITIES.map(ability => {
                  const key = ABILITY_SHORT_NAMES[ability];
                  return (
                    <tr key={key}>
                      <td>{ability}</td>
                      <td className="score-value">{charData.abilityScores.total[key]}</td>
                      <td className="modifier-value">{charData.abilityScores.modifiers[key]}</td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>

           <div className="summary-block">
            <h3>Proficiencies</h3>
            <div className="summary-item">
                <span className="summary-item-label">Skills:</span>
                <span className="summary-item-value">{displaySkills}</span>
            </div>
            <div className="summary-item"><span className="summary-item-label">Armor:</span> <span className="summary-item-value">{displayArmorProf}</span></div>
            <div className="summary-item"><span className="summary-item-label">Weapons:</span> <span className="summary-item-value">{displayWeaponProf}</span></div>
            <div className="summary-item"><span className="summary-item-label">Tools:</span> <span className="summary-item-value">{displayToolProf}</span></div>
        </div>

          <div className="summary-block">
            <h3>Equipment</h3>
                <ul className="summary-list">
                    {(charData.equipmentChosen || []).map((item, index) => (
                    <li key={`set-eq-${index}`}>{item}</li>
                    ))}
                    {charData.backgroundEquipment && (
                    <li key="bg-eq">{charData.backgroundEquipment} (from background)</li>
                    )}
                </ul>
          </div>
        </div>
      </div>

      <div className="character-nav-buttons summary-nav-buttons">
        {cameFromManagement ? (
          <button
            type="button"
            className="char-nav-button back-to-list-button"
            onClick={handleGoBackToManagement}
          >
            Back to List
          </button>
        ) : (
          <>
            <button type="button" className="char-nav-button go-back" onClick={handleGoBackToCreationFlow}>
              Go back
            </button>
            <button type="button" className="char-nav-button continue" onClick={handleCreateCharacter}>
              Create Character
            </button>
          </>
        )}
      </div>
    </main>
  );
};

export default CharacterCreationSummary;