import React, { useState, useEffect, useRef } from 'react';
import { useNavigate, useParams, useLocation } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { ReactComponent as PlusIcon } from '../../assets/icons/plus.svg';
import { DND_CLASSES_DATA, DEFAULT_CLASS_INFO } from '../../data/classesData';

const initialClassState = {
    id: '',
    name: '',
    image: null,
    imageFile: null,
    description: '',
    startingEquipment: { optionSets: [{ setA: '', setB: '' }], fixed: [''] },
    proficiencies: { armor: '', weapons: '', tools: '', savingThrows: '', skills: '' },
    skillChoices: { count: 0, options: [''] },
    hitPoints: { hitDice: '', hpAt1stLevel: '', hpAtHigherLevels: '' },
    featuresTable: Array.from({ length: 20 }, (_, i) => {
        const level = i + 1;
        let suffix = 'th';
        if (level === 1 || (level % 10 === 1 && level % 100 !== 11)) suffix = 'st';
        else if (level === 2 || (level % 10 === 2 && level % 100 !== 12)) suffix = 'nd';
        else if (level === 3 || (level % 10 === 3 && level % 100 !== 13)) suffix = 'rd';
        return { level: `${level}${suffix}`, feature: "" };
    }),
};


const CreateEditHomebrewClassPage = ({ mode = 'create' }) => {
    const navigate = useNavigate();
    const location = useLocation();
    const { itemId } = useParams();

    const [classData, setClassData] = useState(initialClassState);
    const imageFileRef = useRef(null);

    useEffect(() => {
        document.body.style.backgroundImage = `url(${woodBackground})`;


        if (mode === 'edit') {
            let itemToEdit = null;
            if (location.state?.itemData) {
                itemToEdit = location.state.itemData;
            } else if (itemId) {
                const storedItems = JSON.parse(localStorage.getItem('skuffrollHomebrewClasses') || '[]');
                itemToEdit = storedItems.find(item => item.id === itemId);
            }

            if (itemToEdit) {
                const mergedData = {
                    ...initialClassState,
                    ...itemToEdit,
                    startingEquipment: {
                        ...initialClassState.startingEquipment,
                        ...(itemToEdit.startingEquipment || {})
                    },
                    proficiencies: {
                        ...initialClassState.proficiencies,
                        ...(itemToEdit.proficiencies || {})
                    },
                    skillChoices: {
                        ...initialClassState.skillChoices,
                        ...(itemToEdit.skillChoices || {})
                    },
                    hitPoints: {
                        ...initialClassState.hitPoints,
                        ...(itemToEdit.hitPoints || {})
                    },
                    featuresTable: itemToEdit.featuresTable && itemToEdit.featuresTable.length === 20
                        ? itemToEdit.featuresTable
                        : initialClassState.featuresTable
                };
                if (!mergedData.startingEquipment.optionSets?.length) mergedData.startingEquipment.optionSets = [{ setA: '', setB: '' }];
                if (!mergedData.startingEquipment.fixed?.length) mergedData.startingEquipment.fixed = [''];
                if (!mergedData.skillChoices.options?.length) mergedData.skillChoices.options = [''];

                setClassData(mergedData);
            } else if (mode === 'edit') {
                alert("Item not found for editing.");
                navigate('/homebrew-editor/classes');
            }
        } else {
            setClassData(prev => ({ ...prev, id: `hb_cls_${Date.now()}` }));
        }
    }, [mode, itemId, location.state]);


    const handleChange = (e, section, field, index = null, subField = null) => {
        const { name, value, type, checked } = e.target;
        const val = type === 'checkbox' ? checked : value;

        setClassData(prev => {
            const newData = { ...prev };
            if (section) {
                if (!newData[section]) newData[section] = {};
                if (index !== null) {
                    if (!newData[section][field]) newData[section][field] = [];
                    if (subField) {
                        if (!newData[section][field][index]) newData[section][field][index] = {};
                        newData[section][field][index][subField] = val;
                    } else {
                        newData[section][field][index] = val;
                    }
                } else {
                    newData[section][field] = val;
                }
            } else {
                newData[name] = val;
            }
            return newData;
        });
    };

    const handleFeatureChange = (index, value) => {
        setClassData(prev => {
            const newFeatures = [...prev.featuresTable];
            newFeatures[index] = { ...newFeatures[index], feature: value };
            return { ...prev, featuresTable: newFeatures };
        });
    };

    const handleImageUpload = (event) => {
        const file = event.target.files[0];
        if (file && file.type.startsWith("image/")) {
            const reader = new FileReader();
            reader.onloadend = () => {
                setClassData(prev => ({ ...prev, image: reader.result, imageFile: file }));
            };
            reader.readAsDataURL(file);
        } else {
            setClassData(prev => ({ ...prev, image: (mode === 'edit' && classData.image && !classData.imageFile) ? classData.image : null, imageFile: null }));
        }
    };

    const addArrayItem = (section, field, subFieldObject = null) => {
        setClassData(prev => {
            const currentArray = prev[section]?.[field] || [];
            const newItem = subFieldObject ? { ...subFieldObject } : '';
            return {
                ...prev,
                [section]: {
                    ...prev[section],
                    [field]: [...currentArray, newItem]
                }
            };
        });
    };
    const removeArrayItem = (section, field, index) => {
        setClassData(prev => {
            const currentArray = prev[section]?.[field] || [];
            if (currentArray.length <= 1 && (field === 'optionSets' || field === 'fixed' || field === 'options')) return prev;
            return {
                ...prev,
                [section]: {
                    ...prev[section],
                    [field]: currentArray.filter((_, i) => i !== index)
                }
            };
        });
    };


    const handleSubmit = (e) => {
        e.preventDefault();
        if (!classData.name.trim()) {
            alert("Class Name is required.");
            return;
        }

        const dataToSave = { ...classData };
        delete dataToSave.imageFile;

        const storageKey = 'skuffrollHomebrewClasses';
        const storedItems = JSON.parse(localStorage.getItem(storageKey) || '[]');

        if (mode === 'edit') {
            const itemIndex = storedItems.findIndex(item => item.id === dataToSave.id);
            if (itemIndex > -1) {
                storedItems[itemIndex] = dataToSave;
            } else {
                storedItems.push(dataToSave);
            }
        } else {
            if (!dataToSave.id || storedItems.some(item => item.id === dataToSave.id)) {
                dataToSave.id = `hb_cls_${Date.now()}_${Math.random().toString(36).substr(2, 5)}`;
            }
            storedItems.push(dataToSave);
        }

        localStorage.setItem(storageKey, JSON.stringify(storedItems));//local
        SaveClassToBackend();
        navigate('/homebrew-editor/classes');
    };

    const SaveClassToBackend = async () => {
        try {
            const response = await fetch("https://localhost:7174/api/homebrewclass/create", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(classData),
            });

            if (!response.ok) {
                const error = await response.text();
                throw new Error(`Server error: ${error}`);
            }

            const result = await response.json();
            return result.characterId;
        } catch (err) {
            console.error("Error saving class:", err);
            throw err;
        }
    }

    return (
        <main className="character-creation-page homebrew-creation-page">
            <h2>{mode === 'create' ? 'Create New Custom Class' : `Edit Custom Class: ${classData.name || ''}`}</h2>
            <form className="homebrew-form" onSubmit={handleSubmit}>
                <div className="form-section">
                    <h3>Basic Information</h3>
                    <div className="form-group">
                        <label htmlFor="name">Class Name:</label>
                        <input type="text" id="name" name="name" className="form-input" value={classData.name} onChange={handleChange} required />
                    </div>
                    <div className="form-group homebrew-image-upload-section">
                        <label>Class Image:</label>
                        <input type="file" accept="image/*" ref={imageFileRef} onChange={handleImageUpload} style={{ display: 'none' }} />
                        <div className="homebrew-image-upload-box" onClick={() => imageFileRef.current.click()}>
                            {classData.image ? <img src={classData.image} alt="Class preview" className="homebrew-image-preview" /> : <span>+ Upload Image</span>}
                        </div>
                    </div>
                    <div className="form-group">
                        <label htmlFor="description">Description:</label>
                        <textarea id="description" name="description" className="form-input" value={classData.description} onChange={handleChange} rows="4" />
                    </div>
                </div>

                <div className="form-section">
                    <h3>Starting Equipment</h3>
                    <div className="array-input-group">
                        <label>Option Sets (e.g., "a greataxe" OR "any martial melee weapon"):</label>
                        {classData.startingEquipment.optionSets.map((option, index) => (
                            <div key={index} className="array-item">
                                <input type="text" placeholder="Set A Option" className="form-input" value={option.setA} onChange={(e) => handleChange(e, 'startingEquipment', 'optionSets', index, 'setA')} />
                                <span>OR</span>
                                <input type="text" placeholder="Set B Option" className="form-input" value={option.setB} onChange={(e) => handleChange(e, 'startingEquipment', 'optionSets', index, 'setB')} />
                                {classData.startingEquipment.optionSets.length > 1 && <button type="button" className="array-item-button" onClick={() => removeArrayItem('startingEquipment', 'optionSets', index)}>-</button>}
                            </div>
                        ))}
                        <button type="button" className="array-item-button" onClick={() => addArrayItem('startingEquipment', 'optionSets', { setA: '', setB: '' })}>+ Add Option Set</button>
                    </div>
                    <div className="array-input-group">
                        <label>Fixed Items (e.g., "An explorer's pack"):</label>
                        {classData.startingEquipment.fixed.map((item, index) => (
                            <div key={index} className="array-item">
                                <input type="text" className="form-input" value={item} onChange={(e) => handleChange(e, 'startingEquipment', 'fixed', index)} />
                                {classData.startingEquipment.fixed.length > 1 && <button type="button" className="array-item-button" onClick={() => removeArrayItem('startingEquipment', 'fixed', index)}>-</button>}
                            </div>
                        ))}
                        <button type="button" className="array-item-button" onClick={() => addArrayItem('startingEquipment', 'fixed')}>+ Add Fixed Item</button>
                    </div>
                </div>

                <div className="form-section">
                    <h3>Proficiencies</h3>
                    {Object.keys(classData.proficiencies).map(profKey => (
                        <div className="form-group" key={profKey}>
                            <label htmlFor={`prof-${profKey}`}>{profKey.charAt(0).toUpperCase() + profKey.slice(1)}:</label>
                            <input type="text" id={`prof-${profKey}`} className="form-input"
                                value={classData.proficiencies[profKey]}
                                onChange={(e) => handleChange(e, 'proficiencies', profKey)} />
                        </div>
                    ))}
                </div>

                <div className="form-section">
                    <h3>Skill Choices</h3>
                    <div className="form-group">
                        <label htmlFor="skillChoiceCount">Number of Skills to Choose:</label>
                        <input type="number" id="skillChoiceCount" className="form-input" style={{ width: '100px' }}
                            value={classData.skillChoices.count} min="0"
                            onChange={(e) => handleChange(e, 'skillChoices', 'count')} />
                    </div>
                    <div className="array-input-group">
                        <label>Available Skill Options:</label>
                        {classData.skillChoices.options.map((option, index) => (
                            <div key={index} className="array-item">
                                <input type="text" className="form-input" value={option}
                                    onChange={(e) => handleChange(e, 'skillChoices', 'options', index)} />
                                {classData.skillChoices.options.length > 1 && <button type="button" className="array-item-button" onClick={() => removeArrayItem('skillChoices', 'options', index)}>-</button>}
                            </div>
                        ))}
                        <button type="button" className="array-item-button" onClick={() => addArrayItem('skillChoices', 'options')}>+ Add Skill Option</button>
                    </div>
                </div>

                <div className="form-section">
                    <h3>Hit Points</h3>
                    {Object.keys(classData.hitPoints).map(hpKey => (
                        <div className="form-group" key={hpKey}>
                            <label htmlFor={`hp-${hpKey}`}>{hpKey.replace(/([A-Z])/g, ' $1').replace(/^./, str => str.toUpperCase())}:</label>
                            <input type="text" id={`hp-${hpKey}`} className="form-input"
                                value={classData.hitPoints[hpKey]}
                                onChange={(e) => handleChange(e, 'hitPoints', hpKey)} />
                        </div>
                    ))}
                </div>


                <div className="form-section">
                    <h3>Class Features by Level</h3>
                    <table className="features-table-input">
                        <thead><tr><th>Level</th><th>Feature Description</th></tr></thead>
                        <tbody>
                            {classData.featuresTable.map((entry, index) => (
                                <tr key={index}>
                                    <td>{entry.level}</td>
                                    <td>
                                        <input
                                            type="text"
                                            className="form-input"
                                            value={entry.feature}
                                            onChange={(e) => handleFeatureChange(index, e.target.value)}
                                        />
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>

                <div className="homebrew-form-actions">
                    <button type="button" className="form-button cancel" onClick={() => navigate('/homebrew-editor/classes')}>Cancel</button>
                    <button type="submit" className="form-button create">{mode === 'create' ? 'Create Class' : 'Save Changes'}</button>
                </div>
            </form>
        </main>
    );
};

export default CreateEditHomebrewClassPage;