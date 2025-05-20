import React, { useState, useEffect, useMemo, useCallback } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { DND_RACES_DATA } from '../../data/racesData';
import { ABILITIES, ABILITY_SHORT_NAMES, POINT_BUY_COST, MAX_POINT_BUY_SCORE, MIN_POINT_BUY_SCORE, TOTAL_POINTS_BUDGET, calculateModifier } from '../../data/abilityScoresData';
import DiceIcon from '../../assets/icons/casino.png';


const CharacterCreationPage6 = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [characterData, setCharacterData] = useState(null);
  const [raceDetails, setRaceDetails] = useState(null);
  const [useRollSystem, setUseRollSystem] = useState(false);

  const [baseScores, setBaseScores] = useState(
    ABILITIES.reduce((acc, ability) => ({ ...acc, [ABILITY_SHORT_NAMES[ability]]: 8 }), {})
  );

  const [asiChoices, setAsiChoices] = useState([]);
  const [availableAsiChoices, setAvailableAsiChoices] = useState([]);
  const [numAsiToChoose, setNumAsiToChoose] = useState(0);


  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    if (location.state && location.state.charData) {
      const data = location.state.charData;
      setCharacterData(data);
      setUseRollSystem(data.options?.allowRollStats || false);
      if (data.race && DND_RACES_DATA[data.race]) {
        const rd = DND_RACES_DATA[data.race];
        let subRaceDetails = null;
        if (data.subrace && rd.subraces && rd.subraces[data.subrace]) {
            subRaceDetails = rd.subraces[data.subrace];
        }
        setRaceDetails({ ...rd, subraceData: subRaceDetails });

        if (rd.abilityScoreIncrease?.choices) {
            setNumAsiToChoose(rd.abilityScoreIncrease.choices[0].count);
            setAvailableAsiChoices(rd.abilityScoreIncrease.choices[0].availableStats.map(s => ABILITY_SHORT_NAMES[s]));
            setAsiChoices(Array(rd.abilityScoreIncrease.choices[0].count).fill({statKey: '', value: rd.abilityScoreIncrease.choices[0].value}));
        }
        if (data.abilityScores) setBaseScores(data.abilityScores.base);
        if (data.abilityScores?.asiChoices) setAsiChoices(data.abilityScores.asiChoices);

      }
    } else {
      navigate('/character-creation/step5');
    }
  }, [location.state, navigate]);

  const racialBonuses = useMemo(() => {
    const bonuses = ABILITIES.reduce((acc, ability) => ({ ...acc, [ABILITY_SHORT_NAMES[ability]]: 0 }), {});
    if (!raceDetails) return bonuses;

    for (const [stat, value] of Object.entries(raceDetails.abilityScoreIncrease || {})) {
      if (ABILITIES.map(a => ABILITY_SHORT_NAMES[a]).includes(stat)) {
        bonuses[stat] = (bonuses[stat] || 0) + value;
      }
    }
    if (raceDetails.subraceData && raceDetails.subraceData.abilityScoreIncrease) {
      for (const [stat, value] of Object.entries(raceDetails.subraceData.abilityScoreIncrease)) {
         if (ABILITIES.map(a => ABILITY_SHORT_NAMES[a]).includes(stat)) {
            bonuses[stat] = (bonuses[stat] || 0) + value;
        }
      }
    }
    asiChoices.forEach(choice => {
      if (choice.statKey) {
        bonuses[choice.statKey] = (bonuses[choice.statKey] || 0) + choice.value;
      }
    });
    return bonuses;
  }, [raceDetails, asiChoices]);


  const totalScores = useMemo(() => ABILITIES.reduce((acc, ability) => {
    const key = ABILITY_SHORT_NAMES[ability];
    acc[key] = (baseScores[key] || 0) + (racialBonuses[key] || 0);
    return acc;
  }, {}), [baseScores, racialBonuses]);

  const modifiers = useMemo(() => ABILITIES.reduce((acc, ability) => {
    const key = ABILITY_SHORT_NAMES[ability];
    acc[key] = calculateModifier(totalScores[key] || 0);
    return acc;
  }, {}), [totalScores]);

  const pointCosts = useMemo(() => ABILITIES.reduce((acc, ability) => {
    const key = ABILITY_SHORT_NAMES[ability];
    acc[key] = POINT_BUY_COST[baseScores[key]] || 0;
    return acc;
  }, {}), [baseScores]);

  const totalPointsSpent = useMemo(() => {
    if (useRollSystem) return 0;
    return Object.values(pointCosts).reduce((sum, cost) => sum + cost, 0);
  }, [pointCosts, useRollSystem]);


  const handleScoreChange = useCallback((abilityKey, delta) => {
    if (useRollSystem) return;
    setBaseScores(prev => {
      const currentScore = prev[abilityKey];
      const potentialNewScore = currentScore + delta;

      if (potentialNewScore < MIN_POINT_BUY_SCORE || potentialNewScore > MAX_POINT_BUY_SCORE) {
        return prev;
      }

      let newTotalSpent = 0;
      for (const abKey of Object.keys(prev)) {
        if (abKey === abilityKey) {
          newTotalSpent += POINT_BUY_COST[potentialNewScore];
        } else {
          newTotalSpent += POINT_BUY_COST[prev[abKey]];
        }
      }

      if (newTotalSpent <= TOTAL_POINTS_BUDGET) {
        return { ...prev, [abilityKey]: potentialNewScore };
      }
      return prev;
    });
  }, [useRollSystem]);

  const handleRollScore = useCallback((abilityKey) => {
    if (!useRollSystem) return;
    const roll = Math.floor(Math.random() * (14 - 8 + 1)) + 8;
    setBaseScores(prev => ({ ...prev, [abilityKey]: roll }));
  }, [useRollSystem]);

  const handleResetScores = useCallback(() => {
    setBaseScores(ABILITIES.reduce((acc, ability) => ({ ...acc, [ABILITY_SHORT_NAMES[ability]]: 8 }), {}));
    if (raceDetails?.abilityScoreIncrease?.choices) {
        setAsiChoices(Array(raceDetails.abilityScoreIncrease.choices[0].count).fill({statKey: '', value: raceDetails.abilityScoreIncrease.choices[0].value}));
    }
  }, [raceDetails]);

  const handleAsiChoiceChange = (index, selectedStatKey) => {
    if (asiChoices.some((c, i) => i !== index && c.statKey === selectedStatKey)) {
        alert(`${selectedStatKey.toUpperCase()} is already selected for another bonus.`);
        return;
    }
    setAsiChoices(prev => {
        const newChoices = [...prev];
        newChoices[index] = { ...newChoices[index], statKey: selectedStatKey };
        return newChoices;
    });
  };


  const handleGoBack = () => navigate('/character-creation/step5', { state: { charData: characterData } });
  const handleContinue = () => {
    if (!useRollSystem && totalPointsSpent > TOTAL_POINTS_BUDGET) {
      alert(`Points spent (${totalPointsSpent}) exceeds budget (${TOTAL_POINTS_BUDGET}).`);
      return;
    }
    if (numAsiToChoose > 0 && asiChoices.some(choice => !choice.statKey)) {
        alert(`Please assign all ${numAsiToChoose} racial ability score bonuses.`);
        return;
    }

    const finalCharacterData = {
      ...characterData,
      abilityScores: {
        base: baseScores,
        racial: racialBonuses,
        total: totalScores,
        modifiers: modifiers,
        asiChoices: asiChoices,
        pointBuySpent: useRollSystem ? null : totalPointsSpent,
        generationMethod: useRollSystem ? 'roll' : 'pointbuy',
      },
    };
    navigate('/character-creation/summary', { state: { finalCharData: finalCharacterData } });
  };

  if (!characterData || !raceDetails) return <div className="character-creation-page"><p>Loading character data...</p></div>;

  return (
    <main className="character-creation-page char-creation-stats-page">
      <div className="stats-allocation-layout">
        <div className="stats-header-info">
          <p>Allocate Ability Scores for <strong>{characterData.name}</strong> ({raceDetails.name})</p>
          <p>Method: <strong>{useRollSystem ? "Roll for Stats" : "Point Buy"}</strong></p>
        </div>
        {raceDetails.abilityScoreIncrease?.choices && numAsiToChoose > 0 && (
          <div className="asi-choice-section">
            {asiChoices.map((choice, index) => (
              <div key={index} className="asi-choice-group">
                <label htmlFor={`asi-choice-${index}`}>Ability Score Bonus #{index + 1}:</label>
                <select
                  id={`asi-choice-${index}`}
                  className="form-select"
                  value={choice.statKey}
                  onChange={(e) => handleAsiChoiceChange(index, e.target.value)}
                >
                  <option value="" disabled>Select Stat (+{choice.value})</option>
                  {availableAsiChoices.map(statKey => (
                    <option
                      key={statKey}
                      value={statKey}
                      disabled={asiChoices.some((c, i) => i !== index && c.statKey === statKey)}
                    >
                      {ABILITIES.find(ab => ABILITY_SHORT_NAMES[ab] === statKey)}
                    </option>
                  ))}
                </select>
              </div>
            ))}
          </div>
        )}


        <table className="stats-table">
          <thead>
            <tr>
              <th>Attribute</th>
              <th>Ability Score</th>
              <th></th>
              <th>Racial Bonus</th>
              <th></th>
              <th>Total Score</th>
              <th>Ability Modifier</th>
              {!useRollSystem && <th>Point Cost</th>}
            </tr>
          </thead>
          <tbody>
            {ABILITIES.map(ability => {
              const key = ABILITY_SHORT_NAMES[ability];
              return (
                <tr key={key}>
                  <td>{ability}</td>
                  <td className="ability-score-cell">
                    {useRollSystem ? (
                      <>
                        <span className="ability-score-input as-text">{baseScores[key]}</span>
                        <button className="dice-roll-button" onClick={() => handleRollScore(key)} title={`Roll for ${ability}`}>
                          <img src={DiceIcon} alt="Roll dice" />
                        </button>
                      </>
                    ) : (
                      <>
                        <input type="number" className="ability-score-input" value={baseScores[key]} readOnly />
                        <div className="score-buttons">
                          <button onClick={() => handleScoreChange(key, 1)} disabled={baseScores[key] >= MAX_POINT_BUY_SCORE || totalPointsSpent >= TOTAL_POINTS_BUDGET && POINT_BUY_COST[baseScores[key]+1] > POINT_BUY_COST[baseScores[key]]}>▲</button>
                          <button onClick={() => handleScoreChange(key, -1)} disabled={baseScores[key] <= MIN_POINT_BUY_SCORE}>▼</button>
                        </div>
                      </>
                    )}
                  </td>
                  <td>+</td>
                  <td className="racial-bonus-cell">
                    <span className="racial-bonus-value">{racialBonuses[key]}</span>
                  </td>
                  <td>=</td>
                  <td><span className="total-score-value">{totalScores[key]}</span></td>
                  <td><span className="ability-modifier-value">{modifiers[key]}</span></td>
                  {!useRollSystem && <td><span className="point-cost-value">{pointCosts[key]}</span></td>}
                </tr>
              );
            })}
          </tbody>
        </table>

        <div className="stats-footer">
          <button className="reset-stats-button" onClick={handleResetScores}>Reset</button>
          {!useRollSystem && (
            <div className="total-points-display">
              Total Points: {totalPointsSpent}/{TOTAL_POINTS_BUDGET}
            </div>
          )}
        </div>
      </div>

      <div className="character-nav-buttons stats-page-nav-buttons">
        <button type="button" className="char-nav-button go-back" onClick={handleGoBack}>Go back</button>
        <button type="button" className="char-nav-button continue" onClick={handleContinue}>Continue</button>
      </div>
    </main>
  );
};

export default CharacterCreationPage6;