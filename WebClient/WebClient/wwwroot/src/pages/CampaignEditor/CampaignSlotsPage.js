import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import CampaignSlot from '../../components/CampaignSlot';
import CreateCampaignModal from '../../components/CreateCampaignModal';
import woodBackground from '../../assets/images/general/wood-texture.jpg';


const generateId = () => `campaign_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;

const CampaignSlotsPage = () => {
  const navigate = useNavigate();
  const [campaigns, setCampaigns] = useState(() => {
    const savedCampaigns = localStorage.getItem('skuffrollCampaigns');
    if (savedCampaigns) {
      const parsed = JSON.parse(savedCampaigns);
      if (parsed.length === 6 && parsed.every(c => c && typeof c.id === 'string')) {
          return parsed;
      }
    }
    return Array(6).fill(null).map(() => ({ id: generateId(), name: null, mapImage: null }));
  });
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [currentSlotIndex, setCurrentSlotIndex] = useState(null);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [slotToDeleteIndex, setSlotToDeleteIndex] = useState(null);

   useEffect(() => {
    localStorage.setItem('skuffrollCampaigns', JSON.stringify(campaigns));
  }, [campaigns]);

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
  }, []);


  const handleSlotClick = (index) => {
    const campaign = campaigns[index];
    if (campaign && campaign.name && campaign.mapImage) {
      navigate(`/campaign-editor/${campaign.id}`, { state: { campaign } });
    } else {
      setCurrentSlotIndex(index);
      setIsModalOpen(true);
    }
  };

    const handleCreateCampaign = (name, mapImageBase64) => {
    if (currentSlotIndex === null) return;

    const newCampaigns = [...campaigns];
    newCampaigns[currentSlotIndex] = {
      ...newCampaigns[currentSlotIndex],
      name: name,
      mapImage: mapImageBase64,
    };
    setCampaigns(newCampaigns);
    setIsModalOpen(false);
    setCurrentSlotIndex(null);

        SaveCampaignSlotToBackend();
  };

    const SaveCampaignSlotToBackend = async () => {
        try {
            const response = await fetch("https://localhost:7174/api/campaignslots/create", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(campaigns),
            });

            if (!response.ok) {
                const error = await response.text();
                throw new Error(`Server error: ${error}`);
            }

            const result = await response.json();
            return result.characterId;
        } catch (err) {
            console.error("Error saving class:", err);
            throw err;
        }
    }

  const openDeleteModal = (index) => {
    setSlotToDeleteIndex(index);
    setIsDeleteModalOpen(true);
  };

  const closeDeleteModal = () => {
    setIsDeleteModalOpen(false);
    setSlotToDeleteIndex(null);
  };

  const confirmDeleteCampaign = () => {
    if (slotToDeleteIndex === null) return;

    const newCampaigns = [...campaigns];
    if (newCampaigns[slotToDeleteIndex].mapImage && newCampaigns[slotToDeleteIndex].mapImage.startsWith('blob:')) {
        URL.revokeObjectURL(newCampaigns[slotToDeleteIndex].mapImage);
    }
    newCampaigns[slotToDeleteIndex] = {
      ...newCampaigns[slotToDeleteIndex],
      name: null,
      mapImage: null,
    };
    setCampaigns(newCampaigns);
    closeDeleteModal();
  };

  return (
    <>
      <main className="campaign-slots-page">
        <div className="campaign-slots-grid">
          {campaigns.map((campaignData, index) => (
            <CampaignSlot
              key={campaigns[index].id}
              campaign={campaignData.name ? campaignData : null}
              onClick={() => handleSlotClick(index)}
              onDelete={campaignData.name ? () => openDeleteModal(index) : undefined}
            />
          ))}
        </div>
      </main>
      <CreateCampaignModal
        isOpen={isModalOpen}
        onClose={() => { setIsModalOpen(false); setCurrentSlotIndex(null); }}
        onCreate={handleCreateCampaign}
        initialData={currentSlotIndex !== null && campaigns[currentSlotIndex].name ? campaigns[currentSlotIndex] : null}
      />
      {isDeleteModalOpen && slotToDeleteIndex !== null && (
        <div className="modal-overlay" onClick={closeDeleteModal}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>Delete Campaign</h2>
            <p style={{textAlign: 'center', fontFamily: 'Arial, sans-serif', fontSize: '1.1em', marginBottom: '25px'}}>
              Are you sure you want to delete the campaign "{campaigns[slotToDeleteIndex]?.name || 'this campaign'}"?
              This action cannot be undone.
            </p>
            <div className="modal-buttons">
              <button type="button" className="modal-button cancel" onClick={closeDeleteModal}>
                Cancel
              </button>
              <button type="button" className="modal-button delete" onClick={confirmDeleteCampaign}>
                Delete
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default CampaignSlotsPage;