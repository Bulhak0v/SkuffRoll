import React, { useEffect } from 'react';
import GridTile from '../components/GridTile';

import tile1Img from '../assets/images/homepage/tile1.jpg';
import tile2Img from '../assets/images/homepage/tile2.jpg';
import tile3Img from '../assets/images/homepage/tile3.jpg';
import tile4Img from '../assets/images/homepage/tile4.jpg';
import tile5Img from '../assets/images/homepage/tile5.jpg';
import tile6Img from '../assets/images/homepage/tile6.jpg';

import mountainBackground from '../assets/images/homepage/background.jpg';


const homepageTiles = [
  { id: 1, textLine1: "Character", textLine2: "Management", image: tile1Img, link: "/character-management" },
  { id: 2, textLine1: "Game", textLine2: "Manual", image: tile2Img, link: "/game-manual" },
  { id: 3, textLine1: "Character", textLine2: "Creation", image: tile3Img, link: "/character-creation" },
  { id: 4, textLine1: "Lobby", textLine2: "Creation", image: tile4Img, link: "/lobby-management" },
  { id: 5, textLine1: "Homebrew", textLine2: "Editor", image: tile5Img, link: "/homebrew-editor" },
  { id: 6, textLine1: "Campaign", textLine2: "Editor", image: tile6Img, link: "/campaign-editor" },
];

const Homepage = () => {
  useEffect(() => {
    document.body.classList.remove('game-manual-active');
    document.body.style.backgroundImage = `url(${mountainBackground})`;
  }, []);

  return (
    <main className="homepage-main-content">
      <div className="content-grid-homepage">
        {homepageTiles.map(tile => (
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

export default Homepage;