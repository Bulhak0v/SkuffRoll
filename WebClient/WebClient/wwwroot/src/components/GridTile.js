import React from 'react';
import { Link } from 'react-router-dom';

const GridTile = ({ textLine1, textLine2, image, link, isExternal = false, specialClass = '' }) => {
  const content = (
    <>
      <img src={image} alt={`${textLine1} ${textLine2 || ''}`} />
      <div className="grid-tile-text">
        <span>{textLine1}</span>
        {textLine2 && <span>{textLine2}</span>}
      </div>
    </>
  );

  const tileClassName = `grid-tile ${specialClass}`;

  if (isExternal || !link.startsWith('/')) {
    return (
      <a href={link} className={tileClassName} onClick={(e) => { if (link === '#') { e.preventDefault(); alert('Clicked!'); }}}>
        {content}
      </a>
    );
  }

  return (
    <Link to={link} className={tileClassName}>
      {content}
    </Link>
  );
};

export default GridTile;