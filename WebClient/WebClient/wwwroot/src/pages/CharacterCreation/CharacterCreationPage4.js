import React, { useState, useEffect, useMemo } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { DND_RACES_DATA, DND_RACE_NAMES, DEFAULT_RACE_INFO } from '../../data/racesData';

const CharacterCreationPage4 = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [characterData, setCharacterData] = useState(null);
  const [selectedRaceKey, setSelectedRaceKey] = useState('');
  const [selectedSubraceKey, setSelectedSubraceKey] = useState('');

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
      if (data.race) setSelectedRaceKey(data.race);
      if (data.subrace) setSelectedSubraceKey(data.subrace);
    } else {
      console.warn("No data from Character Creation Step 3. Redirecting.");
      navigate('/character-creation/step3');
    }
  }, [location.state, navigate]);
  
  const raceDetails = useMemo(() => {
    if (!selectedRaceKey || !DND_RACES_DATA[selectedRaceKey]) {
      return DEFAULT_RACE_INFO;
    }
    const baseRace = DND_RACES_DATA[selectedRaceKey];
    let subrace = null;
    if (baseRace.subraces && selectedSubraceKey && baseRace.subraces[selectedSubraceKey]) {
      subrace = baseRace.subraces[selectedSubraceKey];
    }

    const combinedASI = { ...baseRace.abilityScoreIncrease };
    if (subrace && subrace.abilityScoreIncrease) {
      for (const [stat, value] of Object.entries(subrace.abilityScoreIncrease)) {
        combinedASI[stat] = (combinedASI[stat] || 0) + value;
      }
    }
    
    let asiText = Object.entries(combinedASI)
        .filter(([stat, value]) => stat !== 'choice' && stat !== 'choiceCount' && value !== 0)
        .map(([stat, value]) => `${stat.charAt(0).toUpperCase() + stat.slice(1)} +${value}`)
        .join(', ');

    if (combinedASI.choice && combinedASI.choiceCount) {
        asiText += (asiText ? ', plus ' : 'Choose ') + `${combinedASI.choiceCount} other ability score(s) increase by +1 each.`;
    }


    let combinedTraits = [...(baseRace.commonTraits || [])];
    if (subrace && subrace.traits) {
      const subraceTraitNames = subrace.traits.map(t => t.name);
      combinedTraits = combinedTraits.filter(ct => !subraceTraitNames.includes(ct.name));
      combinedTraits.push(...subrace.traits);
    }

    return {
      ...baseRace,
      name: subrace ? `${baseRace.name} (${subrace.name})` : baseRace.name,
      abilityScoreIncreaseText: asiText || "None",
      traits: combinedTraits,
      originalSubraces: baseRace.subraces || null,
    };
  }, [selectedRaceKey, selectedSubraceKey]);


  const handleRaceChange = (event) => {
    setSelectedRaceKey(event.target.value);
    setSelectedSubraceKey('');
  };

  const handleSubraceChange = (event) => {
    setSelectedSubraceKey(event.target.value);
  };

  const handleGoBack = () => {
    navigate('/character-creation/step3', { state: { charData: characterData } });
  };

  const handleContinue = () => {
    if (!selectedRaceKey) { alert("Please select a race."); return; }
    if (raceDetails.originalSubraces && Object.keys(raceDetails.originalSubraces).length > 0 && !selectedSubraceKey) {
      alert("Please select a subrace.");
      return;
    }

   const characterStep4Data = {
      ...characterData,
      race: selectedRaceKey,
      raceName: raceDetails.name,
      subrace: selectedSubraceKey || null,
      abilityScoreIncreases: raceDetails.abilityScoreIncreaseText,
      racialTraits: raceDetails.traits.map(t => ({name: t.name, text: t.text })),
    };
    navigate('/character-creation/step5', { state: { charData: characterStep4Data } });
  };
  
  const getRaceKeyFromName = (name) => {
    return Object.keys(DND_RACES_DATA).find(key => DND_RACES_DATA[key].name === name) || '';
  };

  return (
    <main className="character-creation-page char-creation-race-page">
      <div className="race-selection-header">
        <span>Select race of your character:</span>
        <select
          className="form-select race-selection-dropdown"
          value={selectedRaceKey}
          onChange={handleRaceChange}
        >
          <option value="" disabled>-- Select a Race --</option>
          {DND_RACE_NAMES.map(raceName => (
            <option key={raceName} value={getRaceKeyFromName(raceName)}>
              {raceName}
            </option>
          ))}
        </select>

        {selectedRaceKey && raceDetails.originalSubraces && Object.keys(raceDetails.originalSubraces).length > 0 && (
          <select
            className="form-select race-selection-dropdown"
            value={selectedSubraceKey}
            onChange={handleSubraceChange}
            style={{ marginLeft: '10px' }}
          >
            <option value="" disabled>-- Select Subrace --</option>
            {Object.keys(raceDetails.originalSubraces).map(subKey => (
              <option key={subKey} value={subKey}>
                {raceDetails.originalSubraces[subKey].name}
              </option>
            ))}
          </select>
        )}
      </div>

      <div className="race-details-layout">
        <div className="race-portrait-section">
          <img src={raceDetails.image || DEFAULT_RACE_INFO.image} alt={`${raceDetails.name} art`} className="race-portrait" />
          <div className="race-description-section">
            <p>{raceDetails.description}</p>
          </div>
        </div>

        <div className="race-traits-list-section">
          {selectedRaceKey && (
            <>
              <ul className="race-traits-list">
                <li><strong>Ability Score Increase.</strong> {raceDetails.abilityScoreIncreaseText}</li>
              {raceDetails.traits.map((trait, index) => (
                <li key={index}>
                  <strong>{trait.name}.</strong> {trait.text}
                </li>
              ))}
              </ul>
            </>
          )}
          {!selectedRaceKey && <p>{DEFAULT_RACE_INFO.commonTraits[0].text}</p>}
        </div>
      </div>
      <div className="character-nav-buttons race-selection-nav-buttons">
        <button type="button" className="char-nav-button go-back" onClick={handleGoBack}>
          Go back
        </button>
        <button type="button" className="char-nav-button continue" onClick={handleContinue} disabled={!selectedRaceKey}>
          Continue
        </button>
      </div>
    </main>
  );
};

export default CharacterCreationPage4;