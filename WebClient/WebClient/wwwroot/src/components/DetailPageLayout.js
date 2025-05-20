import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import woodBackground from '../assets/images/general/wood-texture.jpg';
import { ReactComponent as BackArrowIcon } from '../assets/icons/corner-up-left.svg';

const DetailPageLayout = ({ pageTitle, children, backLink }) => {
  const navigate = useNavigate();

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
  }, []);

  return (
    <main className="game-manual-detail-page">
      <div className="detail-page-header">
        <h1 className="detail-page-title">{pageTitle}</h1>
        <button onClick={() => navigate(backLink || '/game-manual')}
          className="go-back-button icon-button"
          aria-label="Go back"
          title="Go back"
        >
          <BackArrowIcon />
        </button>
      </div>
      <div className="detail-page-scrollable-content">
        {children}
      </div>
    </main>
  );
};

export default DetailPageLayout;