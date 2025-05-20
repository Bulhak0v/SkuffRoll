import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { ReactComponent as TrashIcon } from '../../assets/icons/trash.svg';

const EditLobbyListPage = () => {
  const navigate = useNavigate();
  const [lobbies, setLobbies] = useState([]);
  const [allCampaigns, setAllCampaigns] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [lobbyToDelete, setLobbyToDelete] = useState(null);

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';
    document.body.style.backgroundPosition = 'center';
    document.body.style.backgroundRepeat = 'no-repeat';
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.minHeight = '100vh';

    const storedLobbies = JSON.parse(localStorage.getItem('skuffrollLobbies') || '[]');
    setLobbies(storedLobbies);

    const storedCampaigns = JSON.parse(localStorage.getItem('skuffrollCampaigns') || '[]');
    setAllCampaigns(storedCampaigns);

    setIsLoading(false);
  }, []);

  const getCampaignMapImage = (campaignId) => {
    const campaign = allCampaigns.find(c => c.id === campaignId);
    return campaign ? campaign.mapImage : null;
  };

  const handleLobbyClick = (lobbyId) => {
  navigate(`/lobby-management/view/${lobbyId}`);
};

  const openDeleteModal = (lobby) => {
    setLobbyToDelete(lobby);
    setIsDeleteModalOpen(true);
  };

  const confirmDeleteLobby = () => {
    if (!lobbyToDelete) return;
    const updatedLobbies = lobbies.filter(lobby => lobby.id !== lobbyToDelete.id);
    setLobbies(updatedLobbies);
    localStorage.setItem('skuffrollLobbies', JSON.stringify(updatedLobbies));
    setIsDeleteModalOpen(false);
    setLobbyToDelete(null);
  };

  if (isLoading) {
    return <div className="edit-lobby-list-page"><h2>Loading lobbies...</h2></div>;
  }

  return (
    <>
      <main className="edit-lobby-list-page">
        <h2>Your lobby list</h2>
        <div className="lobby-list-container">
          {lobbies.length === 0 ? (
            <p style={{ textAlign: 'center', color: '#ccc', marginTop: '20px' }}>You haven't created any lobbies yet.</p>
          ) : (
            lobbies.map(lobby => {
              const mapImage = getCampaignMapImage(lobby.campaignId);
              return (
                <div key={lobby.id} className="lobby-list-item" >
                  <div className="lobby-item-details" onClick={() => handleLobbyClick(lobby.id)}>
                    {mapImage ? (
                         <div className="lobby-item-thumbnail" style={{ backgroundImage: `url(${mapImage})` }}></div>
                    ) : (
                        <div className="lobby-item-thumbnail no-map"><span>No Map</span></div>
                    )}
                    <span className="lobby-item-name">{lobby.name}</span>
                  </div>
                  <div className="lobby-item-actions">
                    <button
                      className="delete-lobby-button"
                      onClick={(e) => {
                        e.stopPropagation();
                        openDeleteModal(lobby);
                      }}
                      title="Delete Lobby"
                    >
                      <TrashIcon />
                    </button>
                  </div>
                </div>
              );
            })
          )}
        </div>
      </main>

      {isDeleteModalOpen && lobbyToDelete && (
        <div className="modal-overlay" onClick={() => setIsDeleteModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>Delete Lobby</h2>
            <p style={{ textAlign: 'center', fontFamily: 'Arial, sans-serif', fontSize: '1.1em', marginBottom: '25px' }}>
              Are you sure you want to delete the lobby "{lobbyToDelete.name}"?
            </p>
            <div className="modal-buttons">
              <button type="button" className="modal-button cancel" onClick={() => setIsDeleteModalOpen(false)}>
                Cancel
              </button>
              <button type="button" className="modal-button delete" onClick={confirmDeleteLobby}>
                Delete
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default EditLobbyListPage;