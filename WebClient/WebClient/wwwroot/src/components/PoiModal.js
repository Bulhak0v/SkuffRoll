import React, { useState, useEffect } from 'react';

const PoiModal = ({ isOpen, onClose, onSubmit, initialData, mode = 'create' }) => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');

  useEffect(() => {
    if (isOpen) {
      setName(initialData?.name || '');
      setDescription(initialData?.description || '');
    }
  }, [isOpen, initialData]);

  if (!isOpen) return null;

  const handleSubmitLocal = (e) => {
    e.preventDefault();
    if (!name.trim() || !description.trim()) {
      console.warn("Name and Description fields must be filled for Point of Interest.");
      return;
    }
    onSubmit({ name, description });
  };

  const handleDeleteClick = () => {
    onSubmit(null, 'delete');
  };

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <h2>{mode === 'create' ? 'Create New Point of Interest' : 'Edit Point of Interest'}</h2>
        <form onSubmit={handleSubmitLocal}>
          <div className="modal-form-group">
            <label htmlFor="poiName">Name</label>
            <input
              type="text" id="poiName" className="modal-input"
              value={name} onChange={(e) => setName(e.target.value)} required
            />
          </div>
          <div className="modal-form-group">
            <label htmlFor="poiDescription">Description</label>
            <textarea
              id="poiDescription" className="modal-input"
              value={description} onChange={(e) => setDescription(e.target.value)} required
            />
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

export default PoiModal;