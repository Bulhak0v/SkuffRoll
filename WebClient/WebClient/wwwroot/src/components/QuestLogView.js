import React, { useState, useEffect } from 'react';
import { ReactComponent as BackArrowIcon } from '../assets/icons/corner-up-left.svg';

const QuestLogView = ({
  onBack,
  allMapMarkers,
  onRequestCompleteQuest,
  onDeleteQuestFromLogRequest
}) => {
  const [selectedQuest, setSelectedQuest] = useState(null);
  const [questList, setQuestList] = useState([]);

  useEffect(() => {
    const quests = allMapMarkers
      .filter(marker => marker.type === 'quest')
    setQuestList(quests);

    if (selectedQuest && !quests.find(q => q.id === selectedQuest.id)) {
      setSelectedQuest(null);
    } else if (selectedQuest) {
      const updatedSelectedQuest = quests.find(q => q.id === selectedQuest.id);
      setSelectedQuest(updatedSelectedQuest || null);
    }

  }, [allMapMarkers, selectedQuest?.id]);

  const handleQuestSelect = (quest) => {
    setSelectedQuest(quest);
  };

  const handleStatusClick = () => {
    if (selectedQuest && selectedQuest.status !== 'Completed' && onRequestCompleteQuest) {
      onRequestCompleteQuest(selectedQuest);
    }
  };

  const requestDeleteCompletedQuest = () => {
    if (selectedQuest && selectedQuest.status === 'Completed') {
        onDeleteQuestFromLogRequest(selectedQuest);
    }
  };

  return (
    <div className="quest-log-container">
      <div className="lore-book-header">
        <div style={{ width: '32px' }}></div>
        <h3 className="lore-book-title">Quest Log</h3>
        <button className="lore-book-action-button lore-book-back-button" onClick={onBack} title="Back to Journal">
          <BackArrowIcon />
        </button>
      </div>

      <div className="lore-book-layout">
        <div className="lore-book-panel lore-book-panel-left quest-log-info-panel">
          {selectedQuest ? (
            <div className="quest-info-content">
              <h5 className="entry-title">{selectedQuest.name}</h5>
              <p className="entry-description">{selectedQuest.description}</p>
              {selectedQuest.rewards && <p className="entry-description" style={{marginTop: '10px'}}><strong>Rewards:</strong> {selectedQuest.rewards}</p>}
              <div className="quest-status-section">
                <p className="quest-status-text">
                  Status: {' '}
                  <span
                    className={selectedQuest.status !== 'Completed' ? 'quest-status-action' : ''}
                    onClick={selectedQuest.status !== 'Completed' ? handleStatusClick : undefined}
                    title={selectedQuest.status !== 'Completed' ? 'Click to mark as completed' : 'Quest is completed'}
                  >
                    {selectedQuest.status || 'In Progress'}
                  </span>
                </p>
              </div>
              {selectedQuest.status === 'Completed' && (
                <button className="quest-log-delete-button" onClick={requestDeleteCompletedQuest}>
                    Delete Completed Quest
                </button>
              )}
            </div>
          ) : (
            <div className="no-entry-selected-placeholder" />
          )}
        </div>

        <div className="lore-book-panel lore-book-panel-right quest-log-list-panel">
          <ul className="quest-log-entry-list">
            {questList.length > 0 ? questList.map(quest => (
              <li
                key={quest.id}
                className={`${selectedQuest?.id === quest.id ? 'selected' : ''} ${quest.status === 'Completed' ? 'completed' : ''}`}
                onClick={() => handleQuestSelect(quest)}
              >
                {quest.name}
              </li>
            )) : (
              <li className="no-quests-message">No active quests.</li>
            )}
          </ul>
        </div>
      </div>
    </div>
  );
};

export default QuestLogView;