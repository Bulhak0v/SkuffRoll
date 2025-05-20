import React, { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { DND_BACKGROUNDS_DATA, DND_BACKGROUND_NAMES, DEFAULT_BACKGROUND_INFO } from '../../data/backgroundsData';

const CharacterCreationPage5 = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [characterData, setCharacterData] = useState(null);
  const [selectedBackgroundKey, setSelectedBackgroundKey] = useState('');
  const [backgroundDetails, setBackgroundDetails] = useState(DEFAULT_BACKGROUND_INFO);

  const [ideals, setIdeals] = useState('');
  const [bonds, setBonds] = useState('');
  const [flaws, setFlaws] = useState('');

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';
    document.body.style.backgroundPosition = 'center';
    document.body.style.backgroundRepeat = 'no-repeat';
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.minHeight = '100vh';

    if (location.state && location.state.charData) {
      const data = location.state.charData;
      setCharacterData(data);
      if (data.backgroundKey) setSelectedBackgroundKey(data.backgroundKey);
      if (data.story?.ideals) setIdeals(data.story.ideals);
      if (data.story?.bonds) setBonds(data.story.bonds);
      if (data.story?.flaws) setFlaws(data.story.flaws);
    } else {
      console.warn("No data from Character Creation Step 4. Redirecting.");
      navigate('/character-creation/step4');
    }
  }, [location.state, navigate]);

  useEffect(() => {
    if (selectedBackgroundKey && DND_BACKGROUNDS_DATA[selectedBackgroundKey]) {
      setBackgroundDetails(DND_BACKGROUNDS_DATA[selectedBackgroundKey]);
    } else {
      setBackgroundDetails(DEFAULT_BACKGROUND_INFO);
    }
  }, [selectedBackgroundKey]);

  const handleBackgroundChange = (event) => {
    setSelectedBackgroundKey(event.target.value);
  };

  const handleGoBack = () => {
    const currentStepData = {
        ...characterData,
        backgroundKey: selectedBackgroundKey,
        story: { ideals, bonds, flaws }
    };
    navigate('/character-creation/step4', { state: { charData: currentStepData } });
  };

  const handleContinue = () => {
    if (!selectedBackgroundKey) {
      alert("Please select a background.");
      return;
    }

    const characterStep5Data = {
      ...characterData,
      backgroundKey: selectedBackgroundKey,
      backgroundName: backgroundDetails.name,
      backgroundSkillProficiencies: backgroundDetails.skillProficiencies,
      backgroundToolProficiencies: backgroundDetails.toolProficiencies || [],
      backgroundEquipment: backgroundDetails.equipment || "",
      backgroundFeature: backgroundDetails.feature || { name: "", description: "" },
      story: {
        ideals,
        bonds,
        flaws,
      },
      finalSkillProficiencies: [
        ...(characterData.proficiencies?.skillsChosen || []),
        ...(backgroundDetails.skillProficiencies || [])
      ].filter((value, index, self) => self.indexOf(value) === index)
    };

    navigate('/character-creation/step6', { state: { charData: characterStep5Data } });
  };

  const getBackgroundKeyFromName = (name) => {
    return Object.keys(DND_BACKGROUNDS_DATA).find(key => DND_BACKGROUNDS_DATA[key].name === name) || '';
  };

  return (
    <main className="character-creation-page char-creation-background-page">
      <div className="background-selection-layout">
        <div className="background-dropdown-section">
          <span>Select a background:</span>
          <select
            className="form-select background-dropdown"
            value={selectedBackgroundKey}
            onChange={handleBackgroundChange}
          >
            <option value="" disabled>-- Select a Background --</option>
            {DND_BACKGROUND_NAMES.map(bgName => (
              <option key={bgName} value={getBackgroundKeyFromName(bgName)}>
                {bgName}
              </option>
            ))}
          </select>
        </div>

        {selectedBackgroundKey && backgroundDetails.name !== "Unknown" && (
          <div className="background-full-details-display">
            <h3>{backgroundDetails.name}</h3>
            <p className="background-description-text">{backgroundDetails.description}</p>
            
            <div className="background-info-grid">
                <div>
                    <h4>Proficiencies</h4>
                    <p><strong>Skills:</strong> {backgroundDetails.skillProficiencies.join(', ')}</p>
                    {backgroundDetails.toolProficiencies && backgroundDetails.toolProficiencies.length > 0 && (
                        <p><strong>Tools:</strong> {backgroundDetails.toolProficiencies.join(', ')}</p>
                    )}
                </div>
                <div>
                    <h4>Equipment</h4>
                    <p>{backgroundDetails.equipment}</p>
                </div>
            </div>

            <h4>Feature: {backgroundDetails.feature.name}</h4>
            <p>{backgroundDetails.feature.description}</p>
          </div>
        )}

        <div className="background-text-fields-section">
          <div className="form-group">
            <label htmlFor="ideals">Ideals:</label>
            <textarea
              id="ideals"
              className="form-input"
              value={ideals}
              onChange={(e) => setIdeals(e.target.value)}
              placeholder="Describe your character's ideals..."
            />
          </div>
          <div className="form-group">
            <label htmlFor="bonds">Bonds:</label>
            <textarea
              id="bonds"
              className="form-input"
              value={bonds}
              onChange={(e) => setBonds(e.target.value)}
              placeholder="Describe your character's bonds..."
            />
          </div>
          <div className="form-group">
            <label htmlFor="flaws">Flaws:</label>
            <textarea
              id="flaws"
              className="form-input"
              value={flaws}
              onChange={(e) => setFlaws(e.target.value)}
              placeholder="Describe your character's flaws..."
            />
          </div>
        </div>

        <div className="character-nav-buttons background-selection-nav-buttons">
          <button type="button" className="char-nav-button go-back" onClick={handleGoBack}>
            Go back
          </button>
          <button type="button" className="char-nav-button continue" onClick={handleContinue} disabled={!selectedBackgroundKey}>
            Continue
          </button>
        </div>
      </div>
    </main>
  );
};

export default CharacterCreationPage5;