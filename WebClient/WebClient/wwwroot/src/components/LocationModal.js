import React, { useState, useEffect } from 'react';

const LocationModal = ({ isOpen, onClose, onSubmit, initialData, mode = 'create', allQuests = [], onQuestClick }) => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [displayableQuestsInLocation, setDisplayableQuestsInLocation] = useState([]);

  useEffect(() => {
    if (isOpen) {
      setName(initialData?.name || '');
      setDescription(initialData?.description || '');
      const associatedIds = initialData?.questIds || [];
      const questsHere = allQuests.filter(q =>
        associatedIds.includes(q.id) && q.status !== 'Completed'
      );
      setDisplayableQuestsInLocation(questsHere);
    }
  }, [isOpen, initialData, allQuests]);

  if (!isOpen) return null;

  const handleSubmitLocal = (e) => {
    e.preventDefault();
    if (!name.trim() || !description.trim()) {
      console.warn("Name and Description fields must be filled for location.");
      return;
    }
    onSubmit({ name, description, questIds: initialData?.questIds || [] });
  };

  const handleDeleteClick = () => {
    onSubmit(null, 'delete');
  };

  const handleQuestNameClick = (quest) => {
    if (onQuestClick) {
      onQuestClick(quest);
    }
  };

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <h2>{mode === 'create' ? 'Create New Location' : 'Edit Location'}</h2>
        <form onSubmit={handleSubmitLocal}>
          <div className="modal-form-group">
            <label htmlFor="locationName">Location Name</label>
            <input
              type="text" id="locationName" className="modal-input"
              value={name} onChange={(e) => setName(e.target.value)} required
            />
          </div>
          <div className="modal-form-group">
            <label htmlFor="locationDescription">Description</label>
            <textarea
              id="locationDescription" className="modal-input"
              value={description} onChange={(e) => setDescription(e.target.value)} required
            />
          </div>

          <div className="location-modal-quests-section">
            <h4>Quests at this Location:</h4>
            <div className="location-modal-quests-list">
              {displayableQuestsInLocation.length === 0 ? (
                <p className="no-quests" style={{ margin: 0, textIndent: 0 }}>No quests currently at this location.</p>
              ) : (
                <p style={{ margin: 0, textIndent: 0 }}>
                  {displayableQuestsInLocation.map((quest, index) => (
                    <React.Fragment key={quest.id}>
                      <span
                        className="clickable-quest-name-inline"
                        onClick={() => handleQuestNameClick(quest)}
                        title={`Edit quest: ${quest.name}`}
                        role="button"
                        tabIndex={0}
                        onKeyPress={(e) => { if (e.key === 'Enter' || e.key === ' ') handleQuestNameClick(quest);}}
                      >
                        {quest.name}
                      </span>
                      {index < displayableQuestsInLocation.length - 1 && ', '}
                    </React.Fragment>
                  ))}
                </p>
              )}
            </div>
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

export default LocationModal;