import React, { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { DND_CLASSES_DATA } from '../../data/classesData';

const DevelopmentTreePage = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [charData, setCharData] = useState(null);
  const [classFeatures, setClassFeatures] = useState([]);
  const [className, setClassName] = useState('');

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';
    document.body.style.backgroundPosition = 'center';
    document.body.style.backgroundRepeat = 'no-repeat';
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.minHeight = '100vh';

    if (location.state && location.state.charDataForTree) {
      const data = location.state.charDataForTree;
      setCharData(data);
      if (data.class && DND_CLASSES_DATA[data.class]) {
        setClassName(DND_CLASSES_DATA[data.class].name);
        setClassFeatures(DND_CLASSES_DATA[data.class].featuresTable || []);
      } else if (data.classDetailsForHP?.featuresTable) {
        setClassName(data.className || 'Unknown Class');
        setClassFeatures(data.classDetailsForHP.featuresTable);
      } else {
        console.warn("Class data not found for development tree.");
        setClassFeatures(Array.from({ length: 20 }, (_, i) => ({ level: `${i+1}`, feature: "Feature details not available."})));
      }
    } else {
      console.warn("No character data for Development Tree. Redirecting.");
      navigate('/');
    }
  }, [location.state, navigate]);

  const handleGoBack = () => {
    if (charData) {
      navigate('/character-creation/summary', { state: { finalCharData: charData, cameFromManagement: location.state?.cameFromManagement || false } });
    } else {
      navigate(-1);
    }
  };

  if (!charData) {
    return <div className="development-tree-page"><h2>Loading development tree...</h2></div>;
  }

  return (
    <main className="development-tree-page">
      <h2>{className} Development Tree</h2>
      <div className="dev-tree-container">
        <div className="dev-tree-trunk"></div>
        {classFeatures.map((item, index) => (
          <div key={index} className={`dev-tree-level ${index % 2 === 0 ? 'left' : 'right'}`}>
            <div className="dev-tree-level-content">
              <span className="level-tag">{item.level}</span>
              <p>{item.feature}</p>
            </div>
          </div>
        ))}
      </div>
      <button
        type="button"
        className="char-nav-button go-back dev-tree-nav-button"
        onClick={handleGoBack}
      >
        Back to Summary
      </button>
    </main>
  );
};

export default DevelopmentTreePage;