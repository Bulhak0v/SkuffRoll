import React, { useState, useEffect, useRef } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { ReactComponent as PlusIcon } from '../../assets/icons/plus.svg';

const DND_ALIGNMENTS = [
  "Lawful Good", "Neutral Good", "Chaotic Good",
  "Lawful Neutral", "True Neutral", "Chaotic Neutral",
  "Lawful Evil", "Neutral Evil", "Chaotic Evil"
];

const CharacterCreationPage1 = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [avatarPreview, setAvatarPreview] = useState(null);
  const [avatarFile, setAvatarFile] = useState(null);
  const avatarFileRef = useRef(null);

  const [charName, setCharName] = useState('');
  const [alignment, setAlignment] = useState(DND_ALIGNMENTS[4]);
  const [gender, setGender] = useState('');
  const [age, setAge] = useState('');
  const [weight, setWeight] = useState('');
  const [height, setHeight] = useState('');
  const [appearance, setAppearance] = useState('');

  const [allowRollStats, setAllowRollStats] = useState(true);
  const [allowAddContent, setAllowAddContent] = useState(true);
  const [allowHomebrew, setAllowHomebrew] = useState(true);

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';
    document.body.style.backgroundPosition = 'center';
    document.body.style.backgroundRepeat = 'no-repeat';
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.minHeight = '100vh';
  }, []);

  useEffect(() => {
    if (location.state && location.state.charDataToEdit) {
        const data = location.state.charDataToEdit;
        setAvatarPreview(data.avatar || null);
        setCharName(data.name || '');
        setAlignment(data.alignment || DND_ALIGNMENTS[4]);
        setGender(data.gender || '');
        setAge(data.age?.toString() || '');
        setWeight(data.weight || '');
        setHeight(data.height || '');
        setAppearance(data.appearance || '');
        if (data.options) {
            setAllowRollStats(data.options.allowRollStats !== undefined ? data.options.allowRollStats : true);
            setAllowAddContent(data.options.allowAddContent !== undefined ? data.options.allowAddContent : true);
            setAllowHomebrew(data.options.allowHomebrew !== undefined ? data.options.allowHomebrew : true);
        }
    }
  }, [location.state, navigate]);

  const handleAvatarUpload = (event) => {
    const file = event.target.files[0];
    if (file && (file.type.startsWith("image/"))) {
      setAvatarFile(file);
      const reader = new FileReader();
      reader.onloadend = () => {
        setAvatarPreview(reader.result);
      };
      reader.readAsDataURL(file);
    } else {
      setAvatarPreview(null);
      setAvatarFile(null);
    }
  };

  const handleGoBack = () => {
    navigate('/');
  };

  const characterStep1BaseData = {
      avatar: null, name: '', alignment: '', gender: '', age: 0, weight: '', height: '', appearance: '', options: {}
  };

  const existingLaterStepData = (location.state?.charDataToEdit &&
                                   Object.keys(location.state.charDataToEdit).length > Object.keys(characterStep1BaseData).length)
                                   ? location.state.charDataToEdit : {};


  const handleContinue = (e) => {
    e.preventDefault();
    if (!charName.trim() || !alignment) {
      console.warn("Name and Alignment are required.");
      return;
    }
    const characterStep1Data = {
      ...existingLaterStepData,
      avatar: avatarPreview,
      name: charName,
      alignment,
      gender,
      age: parseInt(age) || 0,
      weight,
      height,
      appearance,
      options: {
        allowRollStats,
        allowAddContent,
        allowHomebrew,
      },
    };
    navigate('/character-creation/step2', { state: { charData: characterStep1Data } });
  };

  return (
    <main className="character-creation-page">
      <form className="character-creation-form" onSubmit={handleContinue}>
        <div className="avatar-upload-section">
          <input
            type="file"
            accept="image/png, image/jpeg, image/gif"
            ref={avatarFileRef}
            onChange={handleAvatarUpload}
            style={{ display: 'none' }}
          />
          <div className="avatar-upload-box" onClick={() => avatarFileRef.current.click()}>
            {avatarPreview ? (
              <img src={avatarPreview} alt="Character Avatar" className="avatar-preview" />
            ) : (
              <>
                <PlusIcon className="plus-icon-avatar" />
                <span>Import image</span>
              </>
            )}
          </div>
          <label>Character's avatar</label>
        </div>

        <div className="main-info-section">
          <label htmlFor="charName" className="required">Name:</label>
          <input type="text" id="charName" className="form-input" value={charName} onChange={(e) => setCharName(e.target.value)} />

          <label htmlFor="alignment" className="required">Alignment:</label>
          <select id="alignment" className="form-select" value={alignment} onChange={(e) => setAlignment(e.target.value)}>
            {DND_ALIGNMENTS.map(align => <option key={align} value={align}>{align}</option>)}
          </select>

          <label htmlFor="gender">Gender:</label>
          <input type="text" id="gender" className="form-input" value={gender} onChange={(e) => setGender(e.target.value)} />

          <label htmlFor="age">Age:</label>
          <input type="number" id="age" className="form-input" value={age} onChange={(e) => setAge(e.target.value)} min="0" />

          <label htmlFor="weight">Weight:</label>
          <input type="text" id="weight" className="form-input" value={weight} onChange={(e) => setWeight(e.target.value)} placeholder="e.g., 150 lbs"/>

          <label htmlFor="height">Height:</label>
          <input type="text" id="height" className="form-input" value={height} onChange={(e) => setHeight(e.target.value)} placeholder="e.g., 5'10"/>
        </div>

        <div className="checkboxes-section">
          <div className="character-checkbox-group">
            <input type="checkbox" id="rollStats" checked={allowRollStats} onChange={(e) => setAllowRollStats(e.target.checked)} />
            <label htmlFor="rollStats">Allow rolling for stats</label>
          </div>
          <div className="character-checkbox-group">
            <input type="checkbox" id="addContent" checked={allowAddContent} onChange={(e) => setAllowAddContent(e.target.checked)} />
            <label htmlFor="addContent">Allow additional content</label>
          </div>
          <div className="character-checkbox-group">
            <input type="checkbox" id="homebrewContent" checked={allowHomebrew} onChange={(e) => setAllowHomebrew(e.target.checked)} />
            <label htmlFor="homebrewContent">Allow homebrew content</label>
          </div>
        </div>

        <div className="appearance-description-section">
          <label htmlFor="appearance">Appearance description:</label>
          <textarea
            id="appearance"
            className="appearance-description-textarea"
            value={appearance}
            onChange={(e) => setAppearance(e.target.value)}
          />
        </div>

        <div className="character-nav-buttons">
          <button type="button" className="char-nav-button go-back" onClick={handleGoBack}>
            Go back
          </button>
          <button type="submit" className="char-nav-button continue">
            Continue
          </button>
        </div>
      </form>
    </main>
  );
};

export default CharacterCreationPage1;