import React, { useEffect } from 'react';
import GridTile from '../../components/GridTile';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import homebrewClassesImg from '../../assets/images/homebreweditorpage/homebrewclasses.jpg';
import homebrewRacesImg from '../../assets/images/homebreweditorpage/homebrewraces.jpg';

const homebrewTiles = [
  { id: 'hb-cls', textLine1: "Custom", textLine2: "Classes", image: homebrewClassesImg, link: "/homebrew-editor/classes" },
  { id: 'hb-rac', textLine1: "Custom", textLine2: "Races", image: homebrewRacesImg, link: "/homebrew-editor/races" },
];

const HomebrewEditorMainPage = () => {
  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
  }, []);

  return (
    <main className="homebrew-editor-main-page">
      <div className="content-grid-homebrew-main">
        {homebrewTiles.map(tile => (
          <GridTile
            key={tile.id}
            textLine1={tile.textLine1}
            textLine2={tile.textLine2}
            image={tile.image}
            link={tile.link}
          />
        ))}
      </div>
    </main>
  );
};

export default HomebrewEditorMainPage;