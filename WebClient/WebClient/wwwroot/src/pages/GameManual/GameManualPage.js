import React, { useEffect } from 'react';
import GridTile from '../../components/GridTile';

import racesImg from '../../assets/images/gamemanualpage/races-tile.jpg';
import classesImg from '../../assets/images/gamemanualpage/classes-tile.jpg';
import personalityImg from '../../assets/images/gamemanualpage/personality-tile.jpg';

import woodBackground from '../../assets/images/general/wood-texture.jpg';

const gameManualTiles = [
  { id: 'gm1', textLine1: "Races", image: racesImg, link: "/game-manual/races" },
  { id: 'gm2', textLine1: "Classes", image: classesImg, link: "/game-manual/classes" },
  { id: 'gm3', textLine1: "Personality", textLine2: "and Background", image: personalityImg, link: "/game-manual/personality-background", specialClass: 'alignment-chart' },
];

const GameManualPage = () => {
  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;

    return () => {
    };
  }, []);

  return (
    <main className="game-manual-main-content">
      <div className="content-grid-game-manual">
        {gameManualTiles.map(tile => (
          <GridTile
            key={tile.id}
            textLine1={tile.textLine1}
            textLine2={tile.textLine2}
            image={tile.image}
            link={tile.link}
            specialClass={tile.specialClass || ''}
          />
        ))}
      </div>
    </main>
  );
};

export default GameManualPage;