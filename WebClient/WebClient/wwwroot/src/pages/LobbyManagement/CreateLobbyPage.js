import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';

const CreateLobbyPage = () => {
  const navigate = useNavigate();
  const [lobbyName, setLobbyName] = useState('');
  const [selectedCampaignId, setSelectedCampaignId] = useState('');
  const [allowNonPHB, setAllowNonPHB] = useState(false);
  const [allowHomebrew, setAllowHomebrew] = useState(false);
  const [password, setPassword] = useState('');
  const [availableCampaigns, setAvailableCampaigns] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';
    document.body.style.backgroundPosition = 'center';
    document.body.style.backgroundRepeat = 'no-repeat';
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.minHeight = '100vh';

    const storedCampaigns = JSON.parse(localStorage.getItem('skuffrollCampaigns') || '[]');
    const actualCampaigns = storedCampaigns.filter(campaign => campaign && campaign.name && campaign.mapImage);
    setAvailableCampaigns(actualCampaigns);
    if (actualCampaigns.length > 0) {
        setSelectedCampaignId(actualCampaigns[0].id);
    }
    setIsLoading(false);
  }, []);

  const generateLobbyId = () => {
    return Math.floor(100000000 + Math.random() * 900000000).toString();
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!lobbyName.trim() || !password.trim()) {
      alert("Lobby Name and Password are required.");
      return;
    }
    if (availableCampaigns.length > 0 && !selectedCampaignId) {
        alert("Please select a campaign.");
        return;
    }
    const existingLobbies = JSON.parse(localStorage.getItem('skuffrollLobbies') || '[]');
    if (existingLobbies.some(lobby => lobby.name.toLowerCase() === lobbyName.trim().toLowerCase())) {
        alert("A lobby with this name already exists. Please choose a different name.");
        return;
    }


    const lobbyId = generateLobbyId();
    const newLobby = {
      id: lobbyId,
      name: lobbyName.trim(),
      campaignId: selectedCampaignId,
      allowNonPHB,
      allowHomebrew,
      password,
    };

    existingLobbies.push(newLobby);
    localStorage.setItem('skuffrollLobbies', JSON.stringify(existingLobbies));

    navigate('/lobby-management/success', { state: { lobbyId, lobbyName: newLobby.name } });
  };

  if (isLoading) {
    return <div className="create-lobby-page"><p>Loading campaigns...</p></div>;
  }

  return (
    <main className="create-lobby-page">
      <form className="create-lobby-form" onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="lobbyName">Lobby Name:</label>
          <input
            type="text"
            id="lobbyName"
            className="form-input"
            value={lobbyName}
            onChange={(e) => setLobbyName(e.target.value)}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="campaignSelect">Select a campaign</label>
          <select
            id="campaignSelect"
            className="form-select"
            value={selectedCampaignId}
            onChange={(e) => setSelectedCampaignId(e.target.value)}
            disabled={availableCampaigns.length === 0}
            required={availableCampaigns.length > 0}
          >
            {availableCampaigns.length === 0 ? (
              <option value="">No campaigns available</option>
            ) : (
              availableCampaigns.map(campaign => (
                <option key={campaign.id} value={campaign.id}>
                  {campaign.name}
                </option>
              ))
            )}
          </select>
        </div>

        <div className="checkbox-group">
          <input
            type="checkbox"
            id="allowNonPHB"
            checked={allowNonPHB}
            onChange={(e) => setAllowNonPHB(e.target.checked)}
          />
          <label htmlFor="allowNonPHB">Allow non-player's handbook content</label>
        </div>

        <div className="checkbox-group">
          <input
            type="checkbox"
            id="allowHomebrew"
            checked={allowHomebrew}
            onChange={(e) => setAllowHomebrew(e.target.checked)}
          />
          <label htmlFor="allowHomebrew">Allow homebrew content</label>
        </div>

        <div className="form-group">
          <label htmlFor="password">Create a password:</label>
          <input
            type="password"
            id="password"
            className="form-input"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>

        <button type="submit" className="lobby-action-button" disabled={availableCampaigns.length === 0 && !selectedCampaignId}>
          Create a Lobby
        </button>
      </form>
    </main>
  );
};

export default CreateLobbyPage;