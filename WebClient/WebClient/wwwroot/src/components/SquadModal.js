import React, { useState, useEffect, useRef } from 'react';
import { ReactComponent as PlusIcon } from '../assets/icons/plus.svg';

const SquadModal = ({ isOpen, onClose, onSubmit, initialData, mode = 'create' }) => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [squadImage, setSquadImage] = useState(null);

  const fileInputRef = useRef(null);

  useEffect(() => {
    if (isOpen) {
      setName(initialData?.name || '');
      setDescription(initialData?.description || '');
      setSquadImage(initialData?.image || null);
    }
  }, [isOpen, initialData]);

  if (!isOpen) return null;

  const handleFileChange = (event) => {
    const file = event.target.files[0];
    if (file && (file.type === "image/jpeg" || file.type === "image/png" || file.type === "image/gif")) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setSquadImage(reader.result);
      };
      reader.onerror = () => {
        console.error("Error reading squad image file.");
        setSquadImage(initialData?.image || null);
      };
      reader.readAsDataURL(file);
    } else {
      alert("Please upload a valid image file (JPG, PNG, GIF).");
      setSquadImage(initialData?.image || null);
    }
  };

  const triggerFileInput = () => {
    fileInputRef.current.click();
  };

  const handleSubmitLocal = (e) => {
    e.preventDefault();
    if (!name.trim() || !description.trim() || !squadImage) {
      alert("Name, Description, and Squad Image are required.");
      return;
    }
    onSubmit({ name, description, image: squadImage });
  };

  const handleDeleteClick = () => {
    onSubmit(null, 'delete');
  };

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <h2>{mode === 'create' ? 'Create New Squad' : 'Edit Squad'}</h2>
        <form onSubmit={handleSubmitLocal}>
          <div className="modal-form-group">
            <label htmlFor="squadName">Name</label>
            <input type="text" id="squadName" className="modal-input"
              value={name} onChange={(e) => setName(e.target.value)} required />
          </div>
          <div className="modal-form-group">
            <label htmlFor="squadDescription">Description</label>
            <textarea id="squadDescription" className="modal-input"
              value={description} onChange={(e) => setDescription(e.target.value)} required />
          </div>
          <div className="modal-form-group">
            <label>Squad Image (JPG, PNG, GIF)</label>
            <input
              type="file" accept=".jpg,.jpeg,.png,.gif" style={{ display: 'none' }}
              ref={fileInputRef} onChange={handleFileChange}
            />
            <div className="map-upload-area" onClick={triggerFileInput} role="button" tabIndex="0"
                 onKeyPress={(e) => { if (e.key === 'Enter' || e.key === ' ') triggerFileInput();}}>
              {!squadImage && <PlusIcon className="plus-icon-upload" />}
              {!squadImage && <span>Click to upload image</span>}
              {squadImage && <img src={squadImage} alt="Squad preview" className="map-upload-preview" />}
            </div>
            {squadImage && mode === 'edit' && (
                <button type="button" onClick={() => setSquadImage(null)} style={{marginTop: '5px'}}>
                    Remove Image (will require new upload on save)
                </button>
            )}
          </div>

          <div className="modal-buttons">
            {mode === 'edit' && (
              <button type="button" className="modal-button delete" onClick={handleDeleteClick}>Delete</button>
            )}
            <div style={{ flexGrow: 1 }}></div>
            <button type="button" className="modal-button cancel" onClick={onClose}>Cancel</button>
            <button type="submit" className={`modal-button ${mode === 'create' ? 'create' : 'confirm'}`}>
              {mode === 'create' ? 'Create' : 'Confirm'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default SquadModal;