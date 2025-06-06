import React, { useState, useEffect, useRef } from 'react';
import { useParams, useLocation, useNavigate } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import defaultAvatar from '../../assets/icons/default-avatar.png';

const LobbyViewPage = () => {
  const { lobbyId } = useParams();
  const location = useLocation();
  const navigate = useNavigate();

  const [lobbyData, setLobbyData] = useState(null);
  const [campaignMapUrl, setCampaignMapUrl] = useState('');
  const [chatMessages, setChatMessages] = useState([]);
  const [chatInput, setChatInput] = useState('');
  const [selectedPlayerInfo, setSelectedPlayerInfo] = useState(null);
  const [firstCharacter, setFirstCharacter] = useState(null);

  const MOCK_CURRENT_USER = { username: "John_Doe" };

  useEffect(() => {
    document.body.style.backgroundImage = 'none';
    document.body.style.backgroundColor = '#333';

    const storedLobbies = JSON.parse(localStorage.getItem('skuffrollLobbies') || '[]');
    const currentLobby = storedLobbies.find(l => l.id === lobbyId);

    if (currentLobby) {
      setLobbyData(currentLobby);
      const storedCampaigns = JSON.parse(localStorage.getItem('skuffrollCampaigns') || '[]');
      const campaign = storedCampaigns.find(c => c.id === currentLobby.campaignId);
      if (campaign && campaign.mapImage) {
        setCampaignMapUrl(campaign.mapImage);
      } else {
        setCampaignMapUrl('');
        console.warn("Campaign map not found for this lobby.");
      }
    } else {
      console.error("Lobby not found!");
      navigate('/lobby-management');
    }

    const storedCharacters = JSON.parse(localStorage.getItem('skuffrollCharacters') || '[]');
    if (storedCharacters.length > 0) {
      setFirstCharacter(storedCharacters[0]);
    }

  }, [lobbyId, navigate]);

  const handleSendMessage = (e) => {
    if (e.key === 'Enter' && chatInput.trim() !== '') {
      e.preventDefault();
      const newMessage = {
        user: MOCK_CURRENT_USER.username,
        text: chatInput.trim(),
        timestamp: new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }),
      };
      setChatMessages(prev => [...prev, newMessage]);
      setChatInput('');
    }
  };

  const handlePlayerClick = () => {
    if (firstCharacter) {
      setSelectedPlayerInfo({
        name: firstCharacter.name,
        owner: MOCK_CURRENT_USER.username,
        avatar: firstCharacter.avatar || defaultAvatar,
        characterId: firstCharacter.id,
      });
    } else {
         setSelectedPlayerInfo({
            name: "No Character",
            owner: MOCK_CURRENT_USER.username,
            avatar: defaultAvatar,
            characterId: null,
         });
    }
  };

  const closePlayerPopup = () => {
    setSelectedPlayerInfo(null);
  };

  const handleViewCharacterInfo = (characterId) => {
    if(!characterId) return;
    const storedCharacters = JSON.parse(localStorage.getItem('skuffrollCharacters') || '[]');
    const charToView = storedCharacters.find(c => c.id === characterId);
    if (charToView) {
        navigate('/character-creation/summary', { state: { finalCharData: charToView, cameFromManagement: true } });
    } else {
        alert("Character details not found.");
    }
    closePlayerPopup();
  };
  
  const handleEditCampaign = () => {
      if (lobbyData && lobbyData.campaignId) {
          const storedCampaigns = JSON.parse(localStorage.getItem('skuffrollCampaigns') || '[]');
          const campaignToEdit = storedCampaigns.find(c => c.id === lobbyData.campaignId);
          if (campaignToEdit) {
              navigate(`/campaign-editor/${lobbyData.campaignId}`, { state: { campaign: campaignToEdit } });
          } else {
              alert("Campaign data not found for editing.");
          }
      } else {
          alert("No campaign associated with this lobby to edit.");
      }
  };


  if (!lobbyData) {
    return <div className="lobby-view-page"><p>Loading lobby...</p></div>;
  }

  return (
    <div className="lobby-view-page">
      <div className="lobby-map-area" style={{ backgroundImage: `url(${campaignMapUrl || ''})` }}>
        {selectedPlayerInfo && (
          <div className="player-info-popup">
            <img src={selectedPlayerInfo.avatar} alt={`${selectedPlayerInfo.name}'s portrait`} className="popup-portrait" />
            <div className="popup-details">
              <h3>{selectedPlayerInfo.name}</h3>
              <p><strong>Player:</strong> {selectedPlayerInfo.owner}</p>
              <div className="popup-actions">
                <button className="popup-action-button" onClick={() => handleViewCharacterInfo(selectedPlayerInfo.characterId)}>View Character Info</button>
              </div>
            </div>
            <button onClick={closePlayerPopup} style={{position: 'absolute', top: '10px', right: '10px', background: 'none', border: 'none', fontSize: '1.5em', cursor: 'pointer'}}>×</button>
          </div>
        )}
        <button className="edit-campaign-map-button" onClick={handleEditCampaign}>
            Edit Campaign
        </button>
      </div>

      <aside className="lobby-sidebar">
        <div className="players-list-section">
          <h3>Players:</h3>
          <ul className="players-list">
            <li className="player-item" onClick={handlePlayerClick}>
              <span className="username">{MOCK_CURRENT_USER.username}</span> | <span className="charname">{firstCharacter ? firstCharacter.name : "(No character selected)"}</span>
            </li>
          </ul>
        </div>

        <div className="chat-section">
          <h3>Chat</h3>
          <div className="chat-messages">
            {chatMessages.map((msg, index) => (
              <div key={index} className="chat-message">
                <strong>{msg.user}:</strong> {msg.text} <span style={{fontSize: '0.8em', color: '#999', marginLeft: '5px'}}>({msg.timestamp})</span>
              </div>
            ))}
            {chatMessages.length === 0 && <p style={{textAlign: 'center', color: '#aaa'}}>No messages yet.</p>}
          </div>
          <div className="chat-input-area">
            <input
              type="text"
              className="chat-input"
              placeholder="Type a message here..."
              value={chatInput}
              onChange={(e) => setChatInput(e.target.value)}
              onKeyPress={handleSendMessage}
            />
          </div>
        </div>
      </aside>
    </div>
  );
};

export default LobbyViewPage;