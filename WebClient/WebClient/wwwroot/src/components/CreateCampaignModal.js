import React, { useState, useRef, useEffect } from 'react';
import { ReactComponent as PlusIcon } from '../assets/icons/plus.svg';

const CreateCampaignModal = ({ isOpen, onClose, onCreate, initialData }) => {
  const [campaignName, setCampaignName] = useState('');
  const [mapFile, setMapFile] = useState(null);
  const [mapPreview, setMapPreview] = useState(null);
  const fileInputRef = useRef(null);

  useEffect(() => {
    if (isOpen) {
      setCampaignName(initialData?.name || '');
      setMapFile(null);
      setMapPreview(initialData?.mapImage || null);
    }
  }, [isOpen, initialData]);

  if (!isOpen) return null;

  const handleFileChange = (event) => {
    const file = event.target.files[0];
    if (file && (file.type === "image/jpeg" || file.type === "image/png" || file.type === "image/gif")) {
      setMapFile(file);
      const reader = new FileReader();
      reader.onloadend = () => {
        setMapPreview(reader.result);
      };
      reader.readAsDataURL(file);
    } else {
      alert("Please upload a valid image file (JPG, PNG, GIF).");
      setMapFile(null);
      setMapPreview(initialData?.mapImage || null);
    }
  };

  const triggerFileInput = () => {
    fileInputRef.current.click();
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!campaignName.trim()) {
      alert("Please enter a campaign name.");
      return;
    }
     if (!mapPreview) {
        alert("Please upload a campaign map.");
        return;
    }
    onCreate(campaignName, mapPreview);
    onClose();
  };

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <h2>{initialData?.name ? "Edit Campaign" : "Create New Campaign"}</h2>
        <form onSubmit={handleSubmit}>
          <div className="modal-form-group">
            <label htmlFor="campaignName">Campaign Name</label>
            <input
              type="text"
              id="campaignName"
              className="modal-input"
              value={campaignName}
              onChange={(e) => setCampaignName(e.target.value)}
              required
            />
          </div>
          <div className="modal-form-group">
            <label>Upload Campaign Map (JPG, PNG)</label>
            <input
              type="file"
              accept=".jpg,.jpeg,.png,.gif"
              ref={fileInputRef}
              onChange={handleFileChange}
              style={{ display: 'none' }}
            />
            <div className="map-upload-area" onClick={triggerFileInput} role="button" tabIndex="0"
                 onKeyPress={(e) => { if (e.key === 'Enter' || e.key === ' ') triggerFileInput();}}>
              {!mapPreview && <PlusIcon className="plus-icon-upload" />}
              {!mapPreview && <span>Click to upload map</span>}
              {mapPreview && <img src={mapPreview} alt="Map preview" className="map-upload-preview" />}
            </div>
            {mapPreview && <button type="button" onClick={() => { setMapFile(null); setMapPreview(null);}} style={{marginTop: '5px'}}>Remove Map</button>}

          </div>
          <div className="modal-buttons">
            <button type="button" className="modal-button cancel" onClick={onClose}>
              Cancel
            </button>
            <button type="submit" className="modal-button create">
              {initialData?.name ? "Save Changes" : "Create"}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default CreateCampaignModal;