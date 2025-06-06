import React, { useState, useEffect } from 'react';
import { LORE_CATEGORIES } from './LoreEntryModal';
import { ReactComponent as PlusIcon } from '../assets/icons/plus.svg';
import { ReactComponent as BackArrowIcon } from '../assets/icons/corner-up-left.svg';

const LoreBookView = ({
  onBack,
  loreEntriesData,
  onDeleteLoreEntryRequest,
  onOpenEntryModal
}) => {
  const [selectedCategory, setSelectedCategory] = useState(LORE_CATEGORIES[0]);
  const [selectedEntry, setSelectedEntry] = useState(null);
  const [filteredEntries, setFilteredEntries] = useState([]);

  useEffect(() => {
    if (!selectedCategory || !LORE_CATEGORIES.includes(selectedCategory)) {
        setSelectedCategory(LORE_CATEGORIES[0]);
    }
  }, [selectedCategory]);

  useEffect(() => {
    if (selectedCategory) {
      const entriesInCategory = loreEntriesData.filter(entry => entry.category === selectedCategory);
      setFilteredEntries(entriesInCategory);

      if (selectedEntry) {
        const updatedSelectedEntry = loreEntriesData.find(e => e.id === selectedEntry.id);
        if (updatedSelectedEntry && updatedSelectedEntry.category === selectedCategory) {
          setSelectedEntry(updatedSelectedEntry);
        } else {
          setSelectedEntry(null);
        }
      } else if (entriesInCategory.length > 0 && !selectedEntry) {
      }
    } else {
      setFilteredEntries([]);
      setSelectedEntry(null);
    }
  }, [selectedCategory, loreEntriesData, selectedEntry?.id]);


  const handleEntrySelect = (entry) => {
    setSelectedEntry(entry);
  };

  const handleEditSelectedEntry = () => {
    if (selectedEntry) {
      onOpenEntryModal('edit', selectedEntry);
    }
  };

  const requestDeleteSelectedEntry = () => {
    if (selectedEntry) {
        onDeleteLoreEntryRequest(selectedEntry);
    }
  };

  return (
    <div className="lore-book-container">
      <div className="lore-book-header">
        <button
          className="lore-book-action-button lore-book-add-entry-button"
          onClick={() => onOpenEntryModal('create', null, selectedCategory)}
          title="Add New Lore Entry"
        >
          <PlusIcon />
        </button>
        <h3 className="lore-book-title">Lore Book</h3>
        <button className="lore-book-action-button lore-book-back-button" onClick={onBack} title="Back to Journal">
          <BackArrowIcon />
        </button>
      </div>

      <div className="lore-book-layout">
        <div className="lore-book-panel lore-book-panel-left">
          {selectedEntry ? (
            <div className="lore-entry-content">
              <h5 className="entry-title">{selectedEntry.name}</h5>
              <p className="entry-description">{selectedEntry.information}</p>
              <div className="entry-actions-footer">
                <button className="lore-entry-action-button edit" onClick={handleEditSelectedEntry}>
                  Edit
                </button>
                <button className="lore-entry-action-button delete" onClick={requestDeleteSelectedEntry}>
                  Delete
                </button>
              </div>
            </div>
          ) : (
             <div className="no-entry-selected-placeholder">
             </div>
          )}
        </div>

        <div className="lore-book-panel lore-book-panel-right">
          <div className="lore-categories centered">
            {LORE_CATEGORIES.map(category => (
              <button
                key={category}
                className={`lore-category-button ${selectedCategory === category ? 'selected' : ''}`}
                onClick={() => setSelectedCategory(category)}
              >
                {category}
              </button>
            ))}
          </div>
          <ul className="lore-entry-list centered-list">
            {selectedCategory && filteredEntries.length > 0 ? filteredEntries.map(entry => (
              <li
                key={entry.id}
                className={selectedEntry?.id === entry.id ? 'selected' : ''}
                onClick={() => handleEntrySelect(entry)}
              >
                {entry.name}
              </li>
            )) : (
              <li className="no-entries-in-category">
                {selectedCategory ? "No entries in this category." : "Select a category."}
              </li>
            )}
          </ul>
        </div>
      </div>
    </div>
  );
};

export default LoreBookView;