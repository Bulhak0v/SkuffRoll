import React, { useEffect } from 'react';
import GridTile from '../../components/GridTile';

import createLobbyImg from '../../assets/images/lobbycreationpage/createlobby.jpg';
import editLobbyImg from '../../assets/images/lobbycreationpage/editlobby.jpg';

import woodBackground from '../../assets/images/general/wood-texture.jpg';

const lobbyManagementTiles = [
  { id: 'lm1', textLine1: "Create a", textLine2: "Lobby", image: createLobbyImg, link: "/lobby-management/create" },
  { id: 'lm2', textLine1: "Edit a", textLine2: "Lobby", image: editLobbyImg, link: "/lobby-management/edit" }
];

const LobbyManagementPage = () => {
  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    document.body.style.backgroundSize = 'cover';
    document.body.style.backgroundPosition = 'center';
    document.body.style.backgroundRepeat = 'no-repeat';
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.minHeight = '100vh';
  }, []);

  return (
    <main className="lobby-management-main-content">
      <div className="content-grid-lobby-management">
        {lobbyManagementTiles.map(tile => (
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

export default LobbyManagementPage;