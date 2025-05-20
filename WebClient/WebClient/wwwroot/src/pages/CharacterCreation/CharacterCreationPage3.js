import React, { useState, useEffect, useMemo } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { DND_CLASSES_DATA, DND_CLASS_NAMES, DEFAULT_CLASS_INFO } from '../../data/classesData';

const CharacterCreationPage3 = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [characterData, setCharacterData] = useState(null);
  const [classDetails, setClassDetails] = useState(DEFAULT_CLASS_INFO);
  const [selectedSkills, setSelectedSkills] = useState([]);
  const [selectedEquipmentSet, setSelectedEquipmentSet] = useState('a');

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
      const details = data.class && DND_CLASSES_DATA[data.class] ? DND_CLASSES_DATA[data.class] : DEFAULT_CLASS_INFO;
      setClassDetails(details);
      const skillChoiceCount = details.skillChoices?.count || 0;
      if (data.proficiencies && data.proficiencies.skillsChosen) {
        const prefilledSkills = [...data.proficiencies.skillsChosen];
        while (prefilledSkills.length < skillChoiceCount) {
            prefilledSkills.push('');
        }
        setSelectedSkills(prefilledSkills.slice(0, skillChoiceCount));
      } else {
        setSelectedSkills(Array(skillChoiceCount).fill(''));
      }

      if (data.equipmentSetChoice) {
        setSelectedEquipmentSet(data.equipmentSetChoice);
      } else {
        setSelectedEquipmentSet('a');
      }
    } else {
      console.warn("No data from Character Creation Step 2. Redirecting.");
      navigate('/character-creation/step2');
    }
  }, [location.state, navigate]);

  const handleSkillChange = (index, value) => {
    if (value && selectedSkills.some((skill, i) => i !== index && skill === value)) {
      alert("You have already selected this skill.");
      return;
    }
    const newSkills = [...selectedSkills];
    newSkills[index] = value;
    setSelectedSkills(newSkills);
  };

  const equipmentSets = useMemo(() => {
    const setA = [];
    const setB = [];
    if (classDetails.startingEquipment) {
        (classDetails.startingEquipment.optionSets || []).forEach(choice => {
            if(choice.setA) setA.push(choice.setA);
            if(choice.setB) setB.push(choice.setB);
        });
        (classDetails.startingEquipment.fixed || []).forEach(item => {
            setA.push(item);
            setB.push(item);
        });
    }
    return { setA, setB };
  }, [classDetails]);


  const handleGoBack = () => {
    navigate('/character-creation/step2', { state: { charData: characterData } });
  };

  const handleContinue = () => {
    const requiredSkillCount = classDetails.skillChoices?.count || 0;
    const chosenSkillsCount = selectedSkills.filter(skill => skill !== '').length;
    if (chosenSkillsCount < requiredSkillCount && requiredSkillCount > 0) {
      alert(`Please select ${requiredSkillCount} skill(s).`);
      return;
    }

    const characterStep3Data = {
      ...characterData,
      proficiencies: {
        ...classDetails.proficiencies,
        skillsChosen: selectedSkills.filter(s => s),
      },
      equipmentChosen: selectedEquipmentSet === 'a' ? equipmentSets.setA : equipmentSets.setB,
      equipmentSetChoice: selectedEquipmentSet,
    };

    navigate('/character-creation/step4', { state: { charData: characterStep3Data } });
  };

  const skillChoiceCount = classDetails.skillChoices?.count || 0;
  const skillOptions = classDetails.skillChoices?.options || [];

  return (
    <main className="character-creation-page char-creation-skills-equip-page">
      <div className="skills-equip-layout">
        <div className="skills-equip-portrait-section">
          <img src={classDetails.image || DEFAULT_CLASS_INFO.image} alt={`${classDetails.name} class art`} className="skills-equip-portrait" />
        </div>

        <div className="skills-selection-section">
          <h3>Skill Proficiencies</h3>
          {skillChoiceCount > 0 ? (
            Array.from({ length: skillChoiceCount }).map((_, index) => (
              <div key={index} className="skill-choice-row">
                <span>Select skill #{index + 1}:</span>
                <select
                  className="form-select"
                  value={selectedSkills[index] || ''}
                  onChange={(e) => handleSkillChange(index, e.target.value)}
                >
                  <option value="" disabled>-- Choose a skill --</option>
                  {skillOptions.map(skill => (
                    <option
                      key={skill}
                      value={skill}
                      disabled={selectedSkills.some((s, i) => i !== index && s === skill)}
                    >
                      {skill}
                    </option>
                  ))}
                </select>
              </div>
            ))
          ) : (
            <p>This class gains fixed skill proficiencies.</p>
          )}
        </div>

        <div className="equipment-selection-section">
          <h3>Choose starting equipment:</h3>
          <div className="equipment-choice-box">
            <div className="equipment-set-column">
              <div className="equipment-set-header">
                <span>Set a</span>
                <input
                  type="radio"
                  id="setA"
                  name="equipmentSet"
                  value="a"
                  checked={selectedEquipmentSet === 'a'}
                  onChange={(e) => setSelectedEquipmentSet(e.target.value)}
                />
              </div>
              <ul className="equipment-item-list">
                {equipmentSets.setA.map((item, index) => <li key={`a-${index}`}>{item}</li>)}
              </ul>
            </div>
            <div className="equipment-set-column">
              <div className="equipment-set-header">
                <span>Set b</span>
                 <input
                  type="radio"
                  id="setB"
                  name="equipmentSet"
                  value="b"
                  checked={selectedEquipmentSet === 'b'}
                  onChange={(e) => setSelectedEquipmentSet(e.target.value)}
                />
              </div>
               <ul className="equipment-item-list">
                {equipmentSets.setB.map((item, index) => <li key={`b-${index}`}>{item}</li>)}
              </ul>
            </div>
          </div>
        </div>

        <div className="character-nav-buttons skills-equip-nav-buttons">
          <button type="button" className="char-nav-button go-back" onClick={handleGoBack}>
            Go back
          </button>
          <button type="button" className="char-nav-button continue" onClick={handleContinue}>
            Continue
          </button>
        </div>
      </div>
    </main>
  );
};

export default CharacterCreationPage3;