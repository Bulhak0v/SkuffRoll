import React, { useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';

const LobbySuccessPage = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const { lobbyId, lobbyName } = location.state || {};

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';
    document.body.style.backgroundPosition = 'center';
    document.body.style.backgroundRepeat = 'no-repeat';
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.minHeight = '100vh';

    if (!lobbyId) {
      navigate('/lobby-management');
    }
  }, [lobbyId, navigate]);

  const handleCopyLink = () => {
    const invitationLink = `${lobbyId}`;
    navigator.clipboard.writeText(invitationLink)
      .then(() => {
        alert("Invitation link copied to clipboard!");
      })
      .catch(err => {
        console.error('Failed to copy: ', err);
        alert("Failed to copy link.");
      });
  };

  const handleContinue = () => {
  if (lobbyId) {
    navigate(`/lobby-management/view/${lobbyId}`);
  } else {
    navigate('/lobby-management');
  }
};

  if (!lobbyId) {
    return null;
  }

  return (
    <main className="lobby-success-page">
      <h2>Lobby successfully created!</h2>
      <p>
        Your lobby "{lobbyName}" is ready.
      </p>
      <p>
        Your lobby ID: <span className="lobby-id-display">{lobbyId}</span>
      </p>
      <button onClick={handleCopyLink} className="copy-link-button">
        Copy an invitation link
      </button>
      <button onClick={handleContinue} className="lobby-action-button">
        Continue
      </button>
    </main>
  );
};

export default LobbySuccessPage;