import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { ReactComponent as TrashIcon } from '../../assets/icons/trash.svg';

const CHARACTERS_PER_PAGE = 4;

const CharacterManagementPage = () => {
  const navigate = useNavigate();
  const [allCharacters, setAllCharacters] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [isLoading, setIsLoading] = useState(true);

  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [charToDelete, setCharToDelete] = useState(null);

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';

    const storedCharacters = JSON.parse(localStorage.getItem('skuffrollCharacters') || '[]');
    setAllCharacters(storedCharacters);
    setIsLoading(false);
  }, []);

  const totalPages = Math.ceil(allCharacters.length / CHARACTERS_PER_PAGE);
  const charactersOnCurrentPage = allCharacters.slice(
    (currentPage - 1) * CHARACTERS_PER_PAGE,
    currentPage * CHARACTERS_PER_PAGE
  );

  const handleMoreInfo = (character) => {
    navigate('/character-creation/summary', {
      state: { finalCharData: character, cameFromManagement: true }
    });
  };

  const openDeleteModal = (character) => {
    setCharToDelete(character);
    setIsDeleteModalOpen(true);
  };

  const confirmDeleteCharacter = () => {
    if (!charToDelete) return;
    const updatedCharacters = allCharacters.filter(char => char.id !== charToDelete.id);
    setAllCharacters(updatedCharacters);
    localStorage.setItem('skuffrollCharacters', JSON.stringify(updatedCharacters));
    setIsDeleteModalOpen(false);
    setCharToDelete(null);

    if (charactersOnCurrentPage.length === 1 && currentPage > 1) {
      setCurrentPage(prev => prev - 1);
    }
  };

  if (isLoading) {
    return (
      <div className="character-management-page">
        <h2>Loading characters...</h2>
      </div>
    );
  }

  return (
    <>
      <main className="character-management-page">
        {allCharacters.length === 0 ? (
          <p style={{ textAlign: 'center', fontSize: '1.2em', marginTop: '30px' }}>
            No characters created yet. Go to "Character Creation" to make one!
          </p>
        ) : (
          <>
            <div className="character-slots-grid">
              {charactersOnCurrentPage.map(char => (
                <div key={char.id} className="character-slot-card">
                  {char.avatar ? (
                    <img
                      src={char.avatar}
                      alt={`${char.name}'s portrait`}
                      className="slot-portrait"
                    />
                  ) : (
                    <div className="slot-portrait placeholder">No Portrait</div>
                  )}

                  <div className="slot-info">
                    <div className="slot-info-details">
                      <p><strong>Name:</strong> {char.name}</p>
                      <p><strong>Race:</strong> {char.raceName || 'N/A'}</p>
                      <p><strong>Class:</strong> {char.className || 'N/A'}</p>
                      <p><strong>Background:</strong> {char.backgroundName || 'N/A'}</p>
                      <p><strong>Alignment:</strong> {char.alignment || 'N/A'}</p>
                    </div>

                    <div className="slot-actions">
                      <button
                        className="slot-action-button"
                        onClick={() => handleMoreInfo(char)}
                      >
                        More
                      </button>

                      <button
                        className="slot-delete-button"
                        onClick={() => openDeleteModal(char)}
                        title="Delete Character"
                      >
                        <TrashIcon />
                      </button>
                    </div>
                  </div>
                </div>
              ))}
            </div>

            {totalPages > 1 && (
              <div className="pagination-controls">
                <button
                  className="pagination-button"
                  onClick={() => setCurrentPage(prev => Math.max(1, prev - 1))}
                  disabled={currentPage === 1}
                >
                  &lt; Prev
                </button>

                <span className="page-info">
                  Page {currentPage} of {totalPages}
                </span>

                <button
                  className="pagination-button"
                  onClick={() => setCurrentPage(prev => Math.min(totalPages, prev + 1))}
                  disabled={currentPage === totalPages}
                >
                  Next &gt;
                </button>
              </div>
            )}
          </>
        )}
      </main>

      {isDeleteModalOpen && charToDelete && (
        <div
          className="modal-overlay"
          onClick={() => setIsDeleteModalOpen(false)}
        >
          <div
            className="modal-content"
            onClick={e => e.stopPropagation()}
          >
            <h2>Delete Character</h2>
            <p style={{ textAlign: 'center', fontFamily: 'Arial, sans-serif', fontSize: '1.1em', marginBottom: '25px' }}>
              Are you sure you want to delete <strong>{charToDelete.name}</strong>? This action cannot be undone.
            </p>

            <div className="modal-buttons">
              <button
                type="button"
                className="modal-button cancel"
                onClick={() => setIsDeleteModalOpen(false)}
              >
                Cancel
              </button>

              <button
                type="button"
                className="modal-button delete"
                onClick={confirmDeleteCharacter}
              >
                Delete
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default CharacterManagementPage;