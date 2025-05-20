import React from 'react';
import androidIcon from '../assets/images/homepage/android-icon.png';
import skuffLogo from '../assets/images/homepage/skuff-logo-round.png';

const HomepageFooter = () => {
  return (
    <footer className="app-footer">
      <button className="footer-android-btn" onClick={() => alert('Android version clicked!')} title="Mobile Version">
        <img src={androidIcon} alt="Android Version" />
      </button>
      <div className="ukraine-flag">
        <div className="ukraine-flag-blue"></div>
        <div className="ukraine-flag-yellow"></div>
      </div>
      <div className="footer-logo">
        <img src={skuffLogo} alt="SkuffRoll Logo" />
      </div>
    </footer>
  );
};

export default HomepageFooter;