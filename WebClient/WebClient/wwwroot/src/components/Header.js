import React from 'react';
import { ReactComponent as HomeIcon } from '../assets/icons/home.svg';
import { ReactComponent as UserIcon } from '../assets/icons/user.svg';
import { ReactComponent as MenuIcon } from '../assets/icons/menu.svg';
import { Link, useLocation, useNavigate } from 'react-router-dom';

const Header = () => {
    const location = useLocation();
    const navigate = useNavigate();
    let pageTitle = "SkuffRoll";

    if (location.pathname.startsWith('/profile')) {
    pageTitle = "Profile";
    }

    else if (location.pathname.startsWith('/homebrew-editor'))
      pageTitle = "Homebrew Editor";

    else if (location.pathname.startsWith('/game-manual')) {
        pageTitle = "Game Manual";
    }
    else if (location.pathname === '/character-development-tree') {
    if (location.state && location.state.cameFromManagement) {
      pageTitle = "Character Management";
    } else {
      pageTitle = "Character Creation";
    }}
    else if (location.pathname === '/character-creation/summary') {
    if (location.state && location.state.cameFromManagement)
      pageTitle = "Character Management";
    else
      pageTitle = "Character Creation";
    }
    
    else if (location.pathname.startsWith('/campaign-editor')) {
        pageTitle = "Campaign Editor";
    }
    else if (location.pathname.startsWith('/lobby-management'))
        pageTitle = "Lobby Management";

    else if (location.pathname.startsWith('/character-creation'))
      pageTitle = "Character Creation";
    else if (location.pathname.startsWith('/character-management'))
      pageTitle = "Character Management";


  const handleProfileClick = () => {
    navigate('/profile');
  };

  return (
    <header className="app-header">
      <div className="header-left">
        <button onClick={() => window.location.href = '/'} title="Return to Homescreen">
        <HomeIcon />
        </button>
        <button onClick={handleProfileClick} title="User Profile">
        <UserIcon />
        </button>
      </div>
      <h1 className="site-title">{pageTitle}</h1>
      <div className="header-right">
      </div>
    </header>
  );
};

export default Header;