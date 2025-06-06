import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import defaultAvatar from '../../assets/icons/default-avatar.png';

import charPortrait1 from '../../assets/icons/default-avatar.png';
import charPortrait2 from '../../assets/icons/default-avatar.png';
import charPortrait3 from '../../assets/icons/default-avatar.png';
import charPortrait4 from '../../assets/icons/default-avatar.png';


const UserProfilePage = () => {
  const navigate = useNavigate();
  const [userData, setUserData] = useState(null);
  const [campaignCount, setCampaignCount] = useState(0);
  const [characterCount, setCharacterCount] = useState(0);

  const storedUser = sessionStorage.getItem('currentUser');
  const user = storedUser ? JSON.parse(storedUser) : null;

    useEffect(() => {
        document.body.style.backgroundImage = `url(${woodBackground})`;
        document.body.style.backgroundSize = 'cover';
        document.body.style.backgroundPosition = 'center';
        document.body.style.backgroundRepeat = 'no-repeat';
        document.body.style.backgroundAttachment = 'fixed';
        document.body.style.minHeight = '100vh';

        const storedUser = sessionStorage.getItem('currentUser');
        if (storedUser) {
            const parsedUser = JSON.parse(storedUser);
            setUserData({
                username: parsedUser.login,
                joinedDate: parsedUser.registration_date.toLocaleDateString(),
                profilePicture: null, // TODO: Load profile picture if you have one
            });
        }

        const storedCampaigns = JSON.parse(localStorage.getItem('skuffrollCampaigns') || '[]');
        const createdCampaigns = storedCampaigns.filter(campaign => campaign && campaign.name);
        setCampaignCount(createdCampaigns.length);

        const storedCharacters = JSON.parse(localStorage.getItem('skuffrollCharacters') || '[]');
        setCharacterCount(storedCharacters.length);
    }, []);

  const handleLogout = () => {
    navigate('/login');
  };

  const handleViewMyCharacters = () => {
    navigate('/character-management');
  };

  const getCharacterAvatarsForDisplay = () => {
    const storedCharacters = JSON.parse(localStorage.getItem('skuffrollCharacters') || '[]');
    const avatars = storedCharacters.map(char => char.avatar).filter(avatar => avatar);
    
    const placeholders = [charPortrait1, charPortrait2, charPortrait3, charPortrait4];
    while (avatars.length < 4 && placeholders.length > 0) {
        avatars.push(placeholders.shift());
    }
    return avatars.slice(0, 4);
  };
  const displayAvatars = getCharacterAvatarsForDisplay();


  if (!userData) {
    return <div className="user-profile-page"><p>Loading profile...</p></div>;
  }

  return (
    <main className="user-profile-page">
      <div className="profile-header-section">
        <div style={{flexGrow: 1}}></div>
        <button onClick={handleLogout} className="logout-button">Log out</button>
      </div>

      <div className="profile-content">
        <div className="profile-picture-section">
          <img
            src={userData.profilePicture || defaultAvatar}
            alt={`${userData.username}'s profile`}
            className="profile-picture"
          />
        </div>
        <div className="profile-info-section">
          <div className="profile-info-item">
            <strong>Username:</strong> {userData.username}
          </div>
          <div className="profile-info-item">
            <strong>Joined:</strong> {userData.joinedDate}
          </div>
          <div className="profile-info-item">
            <strong>Campaigns created:</strong> {campaignCount}
          </div>
          <div className="profile-info-item">
            <strong>Characters created:</strong> {characterCount}
          </div>
        </div>

        <div className="my-characters-section">
          <div className="character-previews-container">
            {displayAvatars.map((avatarSrc, index) => (
              <img key={index} src={avatarSrc || defaultAvatar} alt={`Character preview ${index + 1}`} className="char-preview-portrait" />
            ))}
             {displayAvatars.length === 0 && <p style={{color: '#555'}}>No characters to preview yet.</p>}
          </div>
          <button onClick={handleViewMyCharacters} className="view-characters-button-overlay">
            See my characters
          </button>
        </div>
      </div>
    </main>
  );
};

export default UserProfilePage;