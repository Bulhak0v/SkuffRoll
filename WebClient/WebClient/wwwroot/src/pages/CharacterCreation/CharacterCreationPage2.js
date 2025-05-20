import React, { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { DND_CLASSES_DATA, DND_CLASS_NAMES, DEFAULT_CLASS_INFO } from '../../data/classesData';

const CharacterCreationPage2 = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [characterStep1Data, setCharacterStep1Data] = useState(null);
  const [selectedClassKey, setSelectedClassKey] = useState('');
  const [classDetails, setClassDetails] = useState(DEFAULT_CLASS_INFO);

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';
    document.body.style.backgroundPosition = 'center';
    document.body.style.backgroundRepeat = 'no-repeat';
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.minHeight = '100vh';

    if (location.state && location.state.charData) {
      const dataFromPreviousStep = location.state.charData;
      setCharacterStep1Data(dataFromPreviousStep);

      if (dataFromPreviousStep.class) {
        setSelectedClassKey(dataFromPreviousStep.class);
        if (DND_CLASSES_DATA[dataFromPreviousStep.class]) {
          setClassDetails(DND_CLASSES_DATA[dataFromPreviousStep.class]);
        } else {
          setClassDetails(DEFAULT_CLASS_INFO);
        }
      } else {
        setSelectedClassKey('');
        setClassDetails(DEFAULT_CLASS_INFO);
      }
    } else {
      console.warn("No data from Character Creation Step 1 or 3. Redirecting.");
      navigate('/character-creation');
    }
  }, [location.state, navigate]);

  useEffect(() => {
    if (selectedClassKey && DND_CLASSES_DATA[selectedClassKey]) {
      setClassDetails(DND_CLASSES_DATA[selectedClassKey]);
    } else {
      setClassDetails(DEFAULT_CLASS_INFO);
    }
  }, [selectedClassKey, characterStep1Data]);

  const handleClassChange = (event) => {
    const classKey = event.target.value;
    setSelectedClassKey(classKey);
  };

  const handleGoBack = () => {
    navigate('/character-creation', { state: { charDataToEdit: characterStep1Data } });
  };

  const handleContinue = () => {
    if (!selectedClassKey) {
      alert("Please select a class.");
      return;
    }
    const characterStep2Data = {
      ...characterStep1Data,
      class: selectedClassKey, 
      className: classDetails.name,
      classDetailsForHP: {
          hitPoints: classDetails.hitPoints,
          proficiencies: classDetails.proficiencies
      }
    };
    navigate('/character-creation/step3', { state: { charData: characterStep2Data } });
  };

  const getClassKeyFromName = (name) => {
    return Object.keys(DND_CLASSES_DATA).find(key => DND_CLASSES_DATA[key].name === name) || '';
  };


   return (
    <main className="character-creation-page char-creation-class-page">
      <div className="class-selection-header">
        <span>Select a class for your character:</span>
        <select
          className="form-select class-selection-dropdown"
          value={selectedClassKey}
          onChange={handleClassChange}
        >
          <option value="" disabled>-- Select a Class --</option>
          {DND_CLASS_NAMES.map(className => (
            <option key={className} value={getClassKeyFromName(className)}>
              {className}
            </option>
          ))}
        </select>
      </div>

      <div className="class-details-layout">
        <div className="class-portrait-section">
          <img src={classDetails.image || DEFAULT_CLASS_INFO.image} alt={`${classDetails.name} class art`} className="class-portrait" />
        </div>
        <div className="middle-column-content">
        <div className="class-main-info">
          <h3>{classDetails.name !== "Unknown" ? classDetails.name : "Class Details"}</h3>
          <p>{classDetails.description}</p>
          
          <h3>Starting Equipment {classDetails.name !== "Unknown" && "(set a or set b)"}</h3>
          <ul>
            {classDetails.startingEquipment.optionSets.map((set, idx) => (
                <li key={idx}>
                  Set A: {set.setA} or Set B: {set.setB}
                </li>
              ))}
            {classDetails.startingEquipment.fixed.map((item, index) => (
              <li key={`fix-${index}`}>{item}</li>
            ))}
          </ul>
        </div>
        </div>
        
        <div className="class-proficiencies-hitpoints-wrapper">
          <div className="class-proficiencies-section">
            <h3>Class Proficiencies</h3>
            <ul>
              <li><strong>Armor:</strong> <span>{classDetails.proficiencies.armor}</span></li>
              <li><strong>Weapons:</strong> <span>{classDetails.proficiencies.weapons}</span></li>
              <li><strong>Tools:</strong> <span>{classDetails.proficiencies.tools}</span></li>
              <li><strong>Saving Throws:</strong> <span>{classDetails.proficiencies.savingThrows}</span></li>
              <li><strong>Skills:</strong> <span>{classDetails.proficiencies.skills}</span></li>
            </ul>
          </div>
          
          <div className="class-hitpoints-section">
            <h3>Hit Points</h3>
            <ul>
              <li><strong>Hit Dice:</strong> <span>{classDetails.hitPoints.hitDice}</span></li>
              <li><strong>Hit Points at 1st Level:</strong> <span>{classDetails.hitPoints.hpAt1stLevel}</span></li>
              <li><strong>Hit Points at Higher Levels:</strong> <span>{classDetails.hitPoints.hpAtHigherLevels}</span></li>
            </ul>
          </div>
        </div>


        <div className="features-table-section">
          <table className="features-table">
            <thead>
              <tr>
                <th>Level</th>
                <th>Feature</th>
              </tr>
            </thead>
            <tbody>
              {classDetails.featuresTable.map((item, index) => (
                <tr key={index}>
                  <td>{item.level}</td>
                  <td>{item.feature}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      <div className="character-nav-buttons class-selection-nav-buttons">
        <button type="button" className="char-nav-button go-back" onClick={handleGoBack}>
          Go back
        </button>
        <button type="button" className="char-nav-button continue" onClick={handleContinue} disabled={!selectedClassKey}>
          Continue
        </button>
      </div>
    </main>
  );
};

export default CharacterCreationPage2;