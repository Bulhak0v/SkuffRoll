import React, { useState, useEffect } from 'react';

const LORE_CATEGORIES = ["Characters", "Locations", "World"];

const LoreEntryModal = ({ isOpen, onClose, onSubmit, initialData, mode = 'create' }) => {
  const [name, setName] = useState('');
  const [category, setCategory] = useState(LORE_CATEGORIES[0]);
  const [information, setInformation] = useState('');

  useEffect(() => {
    if (isOpen) {
      setName(initialData?.name || '');
      setCategory(initialData?.category || LORE_CATEGORIES[0]);
      setInformation(initialData?.information || '');
    }
  }, [isOpen, initialData]);

  if (!isOpen) return null;

  const handleSubmitLocal = (e) => {
    e.preventDefault();
    if (!name.trim() || !category.trim() || !information.trim()) {
      alert("Name, Category, and Information fields must be filled.");
      return;
    }
    onSubmit({ name, category, information });
  };

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <h2>{mode === 'create' ? 'Create New Lore Entry' : 'Edit Lore Entry'}</h2>
        <form onSubmit={handleSubmitLocal}>
          <div className="modal-form-group">
            <label htmlFor="loreEntryName">Entry Name</label>
            <input type="text" id="loreEntryName" className="modal-input"
              value={name} onChange={(e) => setName(e.target.value)} required />
          </div>
          <div className="modal-form-group">
            <label htmlFor="loreEntryCategory">Category</label>
            <select
              id="loreEntryCategory"
              className="lore-entry-modal-category-select"
              value={category}
              onChange={(e) => setCategory(e.target.value)}
              required
              disabled={mode === 'edit'}
            >
              {LORE_CATEGORIES.map(cat => (
                <option key={cat} value={cat}>{cat}</option>
              ))}
            </select>
          </div>
          <div className="modal-form-group">
            <label htmlFor="loreEntryInformation">Information</label>
            <textarea id="loreEntryInformation" className="modal-input"
              value={information} onChange={(e) => setInformation(e.target.value)} required
              rows={6}
            />
          </div>
          <div className="modal-buttons">
            <button type="button" className="modal-button cancel" onClick={onClose}>Cancel</button>
            <button type="submit" className="modal-button confirm">
              {mode === 'create' ? 'Create' : 'Confirm Changes'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default LoreEntryModal;
export { LORE_CATEGORIES };