import React, { useState, useEffect } from 'react';

const QuestModal = ({ isOpen, onClose, onSubmit, initialData, mode = 'create' }) => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [rewards, setRewards] = useState('');

  useEffect(() => {
    if (isOpen) {
      setName(initialData?.name || '');
      setDescription(initialData?.description || '');
      setRewards(initialData?.rewards || '');
    }
  }, [isOpen, initialData]);

  if (!isOpen) return null;

  const handleSubmitLocal = (e) => {
        e.preventDefault();
        if (!name.trim() || !description.trim() || !rewards.trim()) {
            console.warn("All fields must be filled.");
            return;
        }
        onSubmit({ name, description, rewards });
    };

    const handleDeleteClick = () => {
        onSubmit(initialData, 'delete');
    };

    return (
        <div className="modal-overlay" onClick={onClose}>
            <div className="modal-content" onClick={(e) => e.stopPropagation()}>
                <h2>{mode === 'create' ? 'Create New Quest' : 'Edit Quest'}</h2>
                <form onSubmit={handleSubmitLocal}>
                     <div className="modal-form-group">
                        <label htmlFor="questName">Quest Name</label>
                        <input
                        type="text"
                        id="questName"
                        className="modal-input"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                        />
                    </div>
                    <div className="modal-form-group">
                        <label htmlFor="questDescription">Description</label>
                        <textarea
                        id="questDescription"
                        className="modal-input"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        required
                        />
                    </div>
                    <div className="modal-form-group">
                        <label htmlFor="questRewards">Rewards</label>
                        <input
                        type="text"
                        id="questRewards"
                        className="modal-input"
                        value={rewards}
                        onChange={(e) => setRewards(e.target.value)}
                        required
                        />
                    </div>
                    <div className="modal-buttons">
                        {mode === 'edit' && (
                        <button type="button" className="modal-button delete" onClick={handleDeleteClick}>
                            Delete
                        </button>
                        )}
                        <div style={{ flexGrow: 1 }}></div>
                        <button type="button" className="modal-button cancel" onClick={onClose}>
                            Cancel
                        </button>
                        <button type="submit" className={`modal-button ${mode === 'create' ? 'create' : 'confirm'}`}>
                            {mode === 'create' ? 'Create' : 'Confirm'}
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default QuestModal;