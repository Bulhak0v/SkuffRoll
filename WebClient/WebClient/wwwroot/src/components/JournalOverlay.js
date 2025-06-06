import React, { useState } from 'react';
import { ReactComponent as CloseIcon } from '../assets/icons/close.svg';
import { ReactComponent as ReturnIcon } from '../assets/icons/corner-up-left.svg';
import LoreBookView from './LoreBookView';
import QuestLogView from './QuestLogView';


const JournalOverlay = ({
  isOpen,
  onClose,
  loreEntries,
  onDeleteLoreEntryRequest,
  onOpenLoreEntryModal,
  allMapMarkersForQuestLog,
  onRequestCompleteQuest,
  onDeleteQuestFromLogRequest,
}) => {
  const [currentView, setCurrentView] = useState('main');
  
  if (!isOpen) return null;

  const handleBackToMainJournal = () => {
    setCurrentView('main');
  };

  const renderContent = () => {
    switch (currentView) {
      case 'lore_book':
        return (
          <LoreBookView
            onBack={handleBackToMainJournal}
            loreEntriesData={loreEntries}
            onDeleteLoreEntryRequest={onDeleteLoreEntryRequest}
            onOpenEntryModal={onOpenLoreEntryModal}
          />
        );
      case 'quest_log':
        return (
          <QuestLogView
            onBack={handleBackToMainJournal}
            allMapMarkers={allMapMarkersForQuestLog}
            onRequestCompleteQuest={onRequestCompleteQuest}
            onDeleteQuestFromLogRequest={onDeleteQuestFromLogRequest}
          />
        );
      default:
        return (
          <>
            <button className="journal-close-button" onClick={onClose} aria-label="Close journal" title="Close journal">
                <CloseIcon />
            </button>
            <h2 className="journal-title">Journal</h2>
            <div className="journal-options">
              <button className="journal-option-button" onClick={() => setCurrentView('quest_log')}>
                Quest Log
              </button>
              <button className="journal-option-button" onClick={() => setCurrentView('lore_book')}>
                Lore Book
              </button>
            </div>
          </>
        );
    }
  };

  const journalContentClass = `journal-content ${currentView === 'lore_book' || currentView === 'quest_log' ? 'lore-book-active-size' : ''}`;

  return (
    <div className="journal-overlay" onClick={currentView === 'main' ? onClose : undefined}>
      <div className={journalContentClass} onClick={(e) => e.stopPropagation()}>
        {renderContent()}
      </div>
    </div>
  );
};

export default JournalOverlay;