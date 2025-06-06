import React from 'react';
import { ReactComponent as PlusIcon } from '../assets/icons/plus.svg';
import { ReactComponent as TrashIcon } from '../assets/icons/trash.svg';

const CampaignSlot = ({ campaign, onClick, onDelete }) => {
  if (!campaign || !campaign.name) {
    return (
      <div className="campaign-slot empty-slot" onClick={onClick} role="button" tabIndex="0"
           onKeyPress={(e) => { if (e.key === 'Enter' || e.key === ' ') onClick();}}>
        <PlusIcon className="plus-icon-slot" />
      </div>
    );
  }

  const handleDeleteClick = (e) => {
    e.stopPropagation();
    if (onDelete) {
      onDelete();
    }
  };

  return (
    <div
      className="campaign-slot filled-slot"
      style={{ backgroundImage: `url(${campaign.mapImage})` }}
      onClick={onClick}
      role="button" tabIndex="0"
      onKeyPress={(e) => { if (e.key === 'Enter' || e.key === ' ') onClick();}}
    >
      <button
        className="delete-campaign-button"
        onClick={handleDeleteClick}
        aria-label="Delete campaign"
        title="Delete campaign"
      >
        <TrashIcon />
      </button>
      <div className="campaign-slot-name">{campaign.name}</div>
    </div>
  );
};

export default CampaignSlot;