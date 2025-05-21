import React, { useState, useEffect, useRef } from 'react';
import { useNavigate, useParams, useLocation } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { ReactComponent as PlusIcon } from '../../assets/icons/plus.svg';
import { ABILITIES, ABILITY_SHORT_NAMES } from '../../data/abilityScoresData';

const initialRaceState = {
  id: '',
  name: '',
  image: null,
  imageFile: null,
  description: '',
  abilityScoreIncrease: ABILITIES.reduce((acc, ability) => ({ ...acc, [ABILITY_SHORT_NAMES[ability]]: 0 }), {}),
  commonTraits: [{ name: '', text: '' }],
  subraces: {},
};

const initialSubraceState = {
  id: '',
  name: '',
  abilityScoreIncrease: ABILITIES.reduce((acc, ability) => ({ ...acc, [ABILITY_SHORT_NAMES[ability]]: 0 }), {}),
  traits: [{ name: '', text: '' }],
};


const CreateEditHomebrewRacePage = ({ mode = 'create' }) => {
  const navigate = useNavigate();
  const location = useLocation();
  const { itemId } = useParams();

  const [raceData, setRaceData] = useState(initialRaceState);
  const imageFileRef = useRef(null);

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;

    if (mode === 'edit') {
      let itemToEdit = null;
      if (location.state?.itemData) {
        itemToEdit = location.state.itemData;
      } else if (itemId) {
        const storedItems = JSON.parse(localStorage.getItem('skuffrollHomebrewRaces') || '[]');
        itemToEdit = storedItems.find(item => item.id === itemId);
      }

      if (itemToEdit) {
        const mergedData = {
          ...initialRaceState,
          ...itemToEdit,
          abilityScoreIncrease: {
            ...initialRaceState.abilityScoreIncrease,
            ...(itemToEdit.abilityScoreIncrease || {}),
          },
          commonTraits: itemToEdit.commonTraits?.length ? itemToEdit.commonTraits : [{ name: '', text: '' }],
          subraces: itemToEdit.subraces || {},
        };
        Object.keys(mergedData.subraces).forEach(subKey => {
            mergedData.subraces[subKey].abilityScoreIncrease = {
                ...initialSubraceState.abilityScoreIncrease,
                ...(mergedData.subraces[subKey].abilityScoreIncrease || {})
            };
            if (!mergedData.subraces[subKey].traits?.length) {
                mergedData.subraces[subKey].traits = [{ name: '', text: '' }];
            }
        });
        setRaceData(mergedData);
      } else if (mode === 'edit') {
        alert("Race not found for editing.");
        navigate('/homebrew-editor/races');
      }
    } else {
      setRaceData(prev => ({...prev, id: `hb_race_${Date.now()}`}));
    }
  }, [mode, itemId, location.state]);


  const handleInputChange = (e, field, subField = null, index = null, section = null, subraceKey = null) => {
    const { name, value, type } = e.target;
    const val = value;

    setRaceData(prev => {
      const newData = JSON.parse(JSON.stringify(prev));

      if (subraceKey) {
        if (!newData.subraces[subraceKey]) newData.subraces[subraceKey] = { ...initialSubraceState, id: subraceKey, name: 'New Subrace' }; // Should exist
        const targetSubrace = newData.subraces[subraceKey];
        if (section === 'abilityScoreIncrease') {
          targetSubrace.abilityScoreIncrease[name] = parseInt(val) || 0;
        } else if (section === 'traits') {
          targetSubrace.traits[index][field] = val;
        } else {
          targetSubrace[name] = val;
        }
      } else {
        if (section === 'abilityScoreIncrease') {
          newData.abilityScoreIncrease[name] = parseInt(val) || 0;
        } else if (section === 'commonTraits') {
          newData.commonTraits[index][field] = val;
        } else {
          newData[name] = val;
        }
      }
      return newData;
    });
  };

  const handleImageUpload = (event) => {
    const file = event.target.files[0];
    if (file && file.type.startsWith("image/")) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setRaceData(prev => ({ ...prev, image: reader.result, imageFile: file }));
      };
      reader.readAsDataURL(file);
    } else {
      setRaceData(prev => ({ ...prev, image: (mode === 'edit' && raceData.image && !raceData.imageFile) ? raceData.image : null, imageFile: null }));
    }
  };

  const addTrait = (section, subraceKey = null) => {
    setRaceData(prev => {
      const newData = JSON.parse(JSON.stringify(prev));
      if (subraceKey) {
        newData.subraces[subraceKey].traits.push({ name: '', text: '' });
      } else {
        newData[section].push({ name: '', text: '' });
      }
      return newData;
    });
  };
  const removeTrait = (section, index, subraceKey = null) => {
    setRaceData(prev => {
      const newData = JSON.parse(JSON.stringify(prev));
      let targetArray;
      if (subraceKey) {
        targetArray = newData.subraces[subraceKey].traits;
      } else {
        targetArray = newData[section];
      }
      if (targetArray.length <= 1) return prev;
      targetArray.splice(index, 1);
      return newData;
    });
  };

  const addSubrace = () => {
    setRaceData(prev => {
      const newData = { ...prev };
      const newSubraceId = `sub_${Date.now()}`;
      newData.subraces[newSubraceId] = { ...initialSubraceState, id: newSubraceId, name: 'New Subrace' };
      return newData;
    });
  };
  const removeSubrace = (subraceKey) => {
    setRaceData(prev => {
      const newData = { ...prev };
      delete newData.subraces[subraceKey];
      return newData;
    });
  };


  const handleSubmit = (e) => {
    e.preventDefault();
    if (!raceData.name.trim()) {
      alert("Race Name is required.");
      return;
    }

    const dataToSave = { ...raceData };
    delete dataToSave.imageFile;

    const storageKey = 'skuffrollHomebrewRaces';
    const storedItems = JSON.parse(localStorage.getItem(storageKey) || '[]');
    
    if (mode === 'edit') {
      const itemIndex = storedItems.findIndex(item => item.id === dataToSave.id);
      if (itemIndex > -1) storedItems[itemIndex] = dataToSave;
      else storedItems.push(dataToSave);
    } else {
      if (!dataToSave.id || storedItems.some(item => item.id === dataToSave.id)) {
        dataToSave.id = `hb_race_${Date.now()}_${Math.random().toString(36).substr(2,5)}`;
      }
      storedItems.push(dataToSave);
    }
    localStorage.setItem(storageKey, JSON.stringify(storedItems));
    navigate('/homebrew-editor/races');
  };


  return (
    <main className="character-creation-page homebrew-creation-page">
      <h2>{mode === 'create' ? 'Create New Custom Race' : `Edit Custom Race: ${raceData.name || ''}`}</h2>
      <form className="homebrew-form" onSubmit={handleSubmit}>
        <div className="form-section">
          <h3>Basic Information</h3>
          <div className="form-group">
            <label htmlFor="name">Race Name:</label>
            <input type="text" id="name" name="name" className="form-input" value={raceData.name} onChange={(e) => handleInputChange(e, 'name')} required />
          </div>
          <div className="form-group homebrew-image-upload-section">
            <label>Race Image:</label>
            <input type="file" accept="image/*" ref={imageFileRef} onChange={handleImageUpload} style={{ display: 'none' }} />
            <div className="homebrew-image-upload-box" onClick={() => imageFileRef.current.click()}>
              {raceData.image ? <img src={raceData.image} alt="Race preview" className="homebrew-image-preview" /> : <span>+ Upload Image</span>}
            </div>
          </div>
          <div className="form-group">
            <label htmlFor="description">Description:</label>
            <textarea id="description" name="description" className="form-input" value={raceData.description} onChange={(e) => handleInputChange(e, 'description')} rows="4" />
          </div>
        </div>

        <div className="form-section">
          <h3>Base Ability Score Increases</h3>
          {ABILITIES.map(ability => {
            const key = ABILITY_SHORT_NAMES[ability];
            return (
              <div className="form-group" key={`base-asi-${key}`}>
                <label htmlFor={`asi-${key}`}>{ability}:</label>
                <input type="number" id={`asi-${key}`} name={key} className="form-input" style={{width: '80px'}}
                       value={raceData.abilityScoreIncrease[key] || 0}
                       onChange={(e) => handleInputChange(e, null, null, null, 'abilityScoreIncrease')} />
              </div>
            );
          })}
        </div>

        <div className="form-section">
          <h3>Common Racial Traits</h3>
          {raceData.commonTraits.map((trait, index) => (
            <div key={`common-trait-${index}`} className="array-input-group">
              <label>Trait #{index + 1}</label>
              <div className="array-item">
                <input type="text" placeholder="Trait Name" className="form-input" value={trait.name} onChange={(e) => handleInputChange(e, 'name', null, index, 'commonTraits')} />
                <button type="button" className="array-item-button" onClick={() => removeTrait('commonTraits', index)} disabled={raceData.commonTraits.length <= 1}>-</button>
              </div>
              <textarea placeholder="Trait Description" className="form-input" value={trait.text} onChange={(e) => handleInputChange(e, 'text', null, index, 'commonTraits')} rows="2"/>
            </div>
          ))}
          <button type="button" className="array-item-button" onClick={() => addTrait('commonTraits')}>+ Add Common Trait</button>
        </div>

        <div className="form-section">
            <h3>Subraces (Optional)</h3>
            {Object.keys(raceData.subraces).map((subraceKey) => {
                const subrace = raceData.subraces[subraceKey];
                return (
                    <div key={subraceKey} className="form-section" style={{borderLeft: '3px solid #888', marginLeft: '10px', paddingLeft: '15px'}}>
                        <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                            <h4>Subrace:</h4>
                            <button type="button" className="array-item-button" style={{backgroundColor: '#d9534f'}} onClick={() => removeSubrace(subraceKey)}>Remove Subrace</button>
                        </div>
                        <div className="form-group">
                            <label htmlFor={`subrace-name-${subraceKey}`}>Subrace Name:</label>
                            <input type="text" id={`subrace-name-${subraceKey}`} name="name" className="form-input"
                                   value={subrace.name} onChange={(e) => handleInputChange(e, null, null, null, null, subraceKey)} />
                        </div>
                        <h5>Ability Score Increases (Subrace)</h5>
                        {ABILITIES.map(ability => {
                            const key = ABILITY_SHORT_NAMES[ability];
                            return (
                                <div className="form-group" key={`sub-asi-${subraceKey}-${key}`}>
                                    <label htmlFor={`sub-asi-${subraceKey}-${key}`}>{ability}:</label>
                                    <input type="number" id={`sub-asi-${subraceKey}-${key}`} name={key} className="form-input" style={{width: '80px'}}
                                           value={subrace.abilityScoreIncrease[key] || 0}
                                           onChange={(e) => handleInputChange(e, null, null, null, 'abilityScoreIncrease', subraceKey)} />
                                </div>
                            );
                        })}
                        <h5>Subrace Traits</h5>
                        {subrace.traits.map((trait, index) => (
                            <div key={`sub-trait-${subraceKey}-${index}`} className="array-input-group">
                                <label>Trait #{index + 1}</label>
                                <div className="array-item">
                                    <input type="text" placeholder="Trait Name" className="form-input" value={trait.name} onChange={(e) => handleInputChange(e, 'name', null, index, 'traits', subraceKey)} />
                                    <button type="button" className="array-item-button" onClick={() => removeTrait('traits', index, subraceKey)} disabled={subrace.traits.length <= 1}>-</button>
                                </div>
                                <textarea placeholder="Trait Description" className="form-input" value={trait.text} onChange={(e) => handleInputChange(e, 'text', null, index, 'traits', subraceKey)} rows="2"/>
                            </div>
                        ))}
                        <button type="button" className="array-item-button" onClick={() => addTrait('traits', subraceKey)}>+ Add Subrace Trait</button>
                    </div>
                );
            })}
            <button type="button" className="array-item-button" onClick={addSubrace}>+ Add Subrace</button>
        </div>


        <div className="homebrew-form-actions">
          <button type="button" className="form-button cancel" onClick={() => navigate('/homebrew-editor/races')}>Cancel</button>
          <button type="submit" className="form-button create">{mode === 'create' ? 'Create Race' : 'Save Changes'}</button>
        </div>
      </form>
    </main>
  );
};

export default CreateEditHomebrewRacePage;