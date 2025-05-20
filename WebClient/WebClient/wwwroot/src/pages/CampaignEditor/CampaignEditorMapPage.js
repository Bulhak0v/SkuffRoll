import React, { useState, useEffect, useRef, useCallback } from 'react';
import { useParams, useLocation, useNavigate } from 'react-router-dom';
import { TransformWrapper, TransformComponent } from 'react-zoom-pan-pinch';
import QuestModal from '../../components/QuestModal';
import LocationModal from '../../components/LocationModal';
import PoiModal from '../../components/PoiModal';
import SquadModal from '../../components/SquadModal';
import LoreEntryModal, { LORE_CATEGORIES } from '../../components/LoreEntryModal';

import { ReactComponent as PlusIcon } from '../../assets/icons/plus.svg';
import { ReactComponent as MinusIcon } from '../../assets/icons/minus.svg';
import { ReactComponent as BookIcon } from '../../assets/icons/book.svg';
import { ReactComponent as ToolIcon1 } from '../../assets/icons/helmet.svg';
import { ReactComponent as ToolIcon2 } from '../../assets/icons/question.svg';
import { ReactComponent as ToolIcon3 } from '../../assets/icons/location.svg';
import { ReactComponent as ToolIcon4 } from '../../assets/icons/exclamation.svg';

import homepageBackground from '../../assets/images/homepage/background.jpg';
import JournalOverlay from '../../components/JournalOverlay';

import { ReactComponent as BackArrowIcon } from '../../assets/icons/corner-up-left.svg';

const generateMarkerId = () => `marker_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;
const generateLoreEntryId = () => `lore_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;

const MapMarker = ({ marker, onClick, scale, allQuestsDataForIndicator }) => {
  if (marker.type === 'squad') {
    return (
      <div
        className="squad-map-marker"
        style={{ left: `${marker.x}%`, top: `${marker.y}%` }}
        onClick={() => onClick(marker)}
        title={marker.name}
      >
        <img src={marker.image} alt={marker.name || 'Squad'} />
      </div>
    );
  }

  return (
    <div
      className="map-marker"
      style={{ left: `${marker.x}%`, top: `${marker.y}%` }}
      onClick={() => onClick(marker)}
      title={marker.name}
    >
      {marker.type === 'quest' && <ToolIcon4 />}
      {marker.type === 'location' && (
        <>
          <ToolIcon3 className="tower-icon" />
          {(() => {
            const activeQuestsInLocation = (marker.questIds || [])
              .map(id => allQuestsDataForIndicator.find(q => q.id === id))
              .filter(q => q && q.status !== 'Completed');
            return activeQuestsInLocation.length > 0;
          })() && (
            <div className="location-marker-quest-indicator"><ToolIcon4 /></div>
          )}
        </>
      )}
      {marker.type === 'poi' && <ToolIcon2 className="poi-icon" />}
    </div>
  );
};

const MapInteractionWrapper = ({ children, scale, positionX, positionY, onMapClick, mapContentRef }) => {
    const handleInternalMapClick = (event) => {
        if (!mapContentRef.current) return;

        const mapRect = mapContentRef.current.getBoundingClientRect();
        const clickX_viewport = event.clientX;
        const clickY_viewport = event.clientY;
        const clickX_on_scaled_map = clickX_viewport - mapRect.left;
        const clickY_on_scaled_map = clickY_viewport - mapRect.top;
        const x_on_original_map = clickX_on_scaled_map / scale;
        const y_on_original_map = clickY_on_scaled_map / scale;

        let imageElement = mapContentRef.current;
        if (mapContentRef.current.firstChild && mapContentRef.current.firstChild.tagName === 'IMG') {
            imageElement = mapContentRef.current.firstChild;
        }

        const displayedImageWidth = imageElement.offsetWidth;
        const displayedImageHeight = imageElement.offsetHeight;

        if (displayedImageWidth === 0 || displayedImageHeight === 0) {
            console.error("Map dimensions are zero (displayedImageWidth/Height), cannot place marker accurately.");
            return;
        }
        
        const xPercent = (x_on_original_map / displayedImageWidth) * 100;
        const yPercent = (y_on_original_map / displayedImageHeight) * 100;


        if (xPercent >= 0 && xPercent <= 100 && yPercent >= 0 && yPercent <= 100) {
            onMapClick(xPercent, yPercent);
        } else {
            alert("Marker must be placed within the map boundaries.");
        }
    };

    return <div
      onClick={onMapClick ? (e) => handleInternalMapClick(e) : undefined}
      onDragOver={(e) => e.preventDefault()}
      onDrop={(e) => {
          e.preventDefault();
      }}
      style={{ width: '100%', height: '100%' }}
    >
      {children}
    </div>;
};

const CampaignEditorMapPage = () => {
  const { campaignId } = useParams();
  const location = useLocation();
  const navigate = useNavigate();

  const [campaignData, setCampaignData] = useState(null);
  const [isToolbarOpen, setIsToolbarOpen] = useState(false);
  const [isPanning, setIsPanning] = useState(false);

  const [markers, setMarkers] = useState([]);
  const [placingMarkerType, setPlacingMarkerType] = useState(null);
  const [pendingMarkerData, setPendingMarkerData] = useState(null);
  const [cursorFollowerPos, setCursorFollowerPos] = useState({ x: 0, y: 0 });

  const [isQuestModalOpen, setIsQuestModalOpen] = useState(false);
  const [editingQuest, setEditingQuest] = useState(null);
  const [questModalMode, setQuestModalMode] = useState('create');

  const [isDeleteQuestModalOpen, setIsDeleteQuestModalOpen] = useState(false);
  const [questToDelete, setQuestToDelete] = useState(null);

  const [isLocationModalOpen, setIsLocationModalOpen] = useState(false);
  const [editingLocation, setEditingLocation] = useState(null);
  const [locationModalMode, setLocationModalMode] = useState('create');
  const [isDeleteLocationModalOpen, setIsDeleteLocationModalOpen] = useState(false);
  const [locationToDelete, setLocationToDelete] = useState(null);

  const [isPoiModalOpen, setIsPoiModalOpen] = useState(false);
  const [editingPoi, setEditingPoi] = useState(null);
  const [poiModalMode, setPoiModalMode] = useState('create');
  const [isDeletePoiModalOpen, setIsDeletePoiModalOpen] = useState(false);
  const [poiToDelete, setPoiToDelete] = useState(null);

  const [isSquadModalOpen, setIsSquadModalOpen] = useState(false);
  const [editingSquad, setEditingSquad] = useState(null);
  const [squadModalMode, setSquadModalMode] = useState('create');
  const [isDeleteSquadModalOpen, setIsDeleteSquadModalOpen] = useState(false);
  const [squadToDelete, setSquadToDelete] = useState(null);

  const draggedQuestIdRef = useRef(null);

  const mapContentRef = useRef(null);

  const [isJournalOpen, setIsJournalOpen] = useState(false);

  const [loreEntries, setLoreEntries] = useState([]);
  const [isLoreEntryModalOpen, setIsLoreEntryModalOpen] = useState(false);
  const [editingLoreEntry, setEditingLoreEntry] = useState(null);
  const [loreEntryModalMode, setLoreEntryModalMode] = useState('create');
  const [preselectedCategoryForNewLore, setPreselectedCategoryForNewLore] = useState(null);

  const [isDeleteLoreEntryModalOpen, setIsDeleteLoreEntryModalOpen] = useState(false);
  const [loreEntryToDelete, setLoreEntryToDelete] = useState(null);

  const [isDeleteQuestFromLogModalOpen, setIsDeleteQuestFromLogModalOpen] = useState(false);
  const [questToDeleteFromLog, setQuestToDeleteFromLog] = useState(null);

  const [isMarkCompleteModalOpen, setIsMarkCompleteModalOpen] = useState(false);
  const [questToMarkComplete, setQuestToMarkComplete] = useState(null);
  
  const allMarkersData = markers;

  useEffect(() => {
    if (location.state && location.state.campaign) {
      const campData = location.state.campaign;
      setCampaignData(campData);
      setMarkers(campData.markers || []);
    } else {
      const storedCampaigns = JSON.parse(localStorage.getItem('skuffrollCampaigns') || '[]');
      const foundCampaign = storedCampaigns.find(c => c.id === campaignId);
      if (foundCampaign && foundCampaign.name) {
        setCampaignData(foundCampaign);
        setMarkers(foundCampaign.markers || []);
      } else {
        alert("Could not load campaign data.");
        navigate('/campaign-editor');
      }
    }

    document.body.style.backgroundImage = `url(${homepageBackground})`;

    return () => {
    };
  }, [campaignId, location.state, navigate]);

  useEffect(() => {
    if (campaignData && campaignData.id) {
      const storedCampaigns = JSON.parse(localStorage.getItem('skuffrollCampaigns') || '[]');
      const campaignIndex = storedCampaigns.findIndex(c => c.id === campaignData.id);
      if (campaignIndex !== -1) {
        storedCampaigns[campaignIndex] = { ...storedCampaigns[campaignIndex], markers };
        localStorage.setItem('skuffrollCampaigns', JSON.stringify(storedCampaigns));
      }
    }
  }, [markers, campaignData]);

  useEffect(() => {
    if (campaignData && campaignData.id) {
      const storedCampaigns = JSON.parse(localStorage.getItem('skuffrollCampaigns') || '[]');
      const currentCampaignFromFile = storedCampaigns.find(c => c.id === campaignData.id);
      if (currentCampaignFromFile && currentCampaignFromFile.loreEntries) {
        setLoreEntries(currentCampaignFromFile.loreEntries);
      } else {
        setLoreEntries([]);
      }
    }
  }, [campaignData]);

  useEffect(() => {
    if (campaignData && campaignData.id) {
      const storedCampaigns = JSON.parse(localStorage.getItem('skuffrollCampaigns') || '[]');
      const campaignIndex = storedCampaigns.findIndex(c => c.id === campaignData.id);
      if (campaignIndex !== -1) {
        storedCampaigns[campaignIndex] = { ...storedCampaigns[campaignIndex], loreEntries };
        localStorage.setItem('skuffrollCampaigns', JSON.stringify(storedCampaigns));
      }
    }
  }, [loreEntries, campaignData]);

  useEffect(() => {
    const handleMouseMove = (e) => {
      if (placingMarkerType) {
        setCursorFollowerPos({ x: e.clientX, y: e.clientY });
      }
    };
    const handleRightClick = (e) => {
      if (placingMarkerType) {
        e.preventDefault();
        setPlacingMarkerType(null);
        setPendingMarkerData(null);
      }
    };

    if (placingMarkerType) {
      window.addEventListener('mousemove', handleMouseMove);
      window.addEventListener('contextmenu', handleRightClick);
    }
    return () => {
      window.removeEventListener('mousemove', handleMouseMove);
      window.removeEventListener('contextmenu', handleRightClick);
    };
  }, [placingMarkerType]);


  const handleOpenQuestModal = (mode = 'create', questData = null) => {
    setQuestModalMode(mode);
    setEditingQuest(questData);
    setIsQuestModalOpen(true);
  };

  const handleQuestModalSubmit = (questDetails, action) => {
    if (action === 'delete' && editingQuest) {
      setQuestToDelete(editingQuest);
      setIsDeleteQuestModalOpen(true);
      setIsQuestModalOpen(false);
      return;
    }

    if (!questDetails) {
      setIsQuestModalOpen(false);
      setEditingQuest(null);
      return;
    }

    if (questModalMode === 'create') {
      setPendingMarkerData({ ...questDetails, type: 'quest', status: 'In Progress' });
      setPlacingMarkerType('quest');
    } else if (questModalMode === 'edit' && editingQuest) {
      setMarkers(prevMarkers =>
        prevMarkers.map(marker =>
          marker.id === editingQuest.id ? { ...marker, ...questDetails, type: 'quest' } : marker
        )
      );
      setEditingQuest(null);
    }
    setIsQuestModalOpen(false);
  };

  const confirmActualQuestDelete = () => {
    if (questToDelete) {
      const deletedQuestId = questToDelete.id;
      setMarkers(prevMarkers =>
        prevMarkers
          .filter(m => m.id !== deletedQuestId)
          .map(m => {
            if (m.type === 'location' && m.questIds?.includes(deletedQuestId)) {
              return { ...m, questIds: m.questIds.filter(id => id !== deletedQuestId) };
            }
            return m;
          })
      );
    }
    setQuestToDelete(null);
    setIsDeleteQuestModalOpen(false);
  };

  const handleUpdateQuestStatusOnMap = (questId, newStatus) => {
    setMarkers(prevMarkers =>
      prevMarkers.map(marker => {
        if (marker.id === questId) {
          const updatedMarker = { ...marker, status: newStatus };
          if (newStatus === 'Completed') {
            delete updatedMarker.x;
            delete updatedMarker.y;
          }
          return updatedMarker;
        }
        return marker;
      })
    );
  };

  const requestDeleteQuestFromLog = (quest) => {
    setQuestToDeleteFromLog(quest);
    setIsDeleteQuestFromLogModalOpen(true);
  };

  const confirmActualQuestFromLogDelete = () => {
    if (questToDeleteFromLog) {
      const deletedQuestId = questToDeleteFromLog.id;
      setMarkers(prevMarkers => prevMarkers.filter(m => m.id !== deletedQuestId));
      setMarkers(prevMarkers =>
        prevMarkers.map(m => {
          if (m.type === 'location' && m.questIds?.includes(deletedQuestId)) {
            return { ...m, questIds: m.questIds.filter(id => id !== deletedQuestId) };
          }
          return m;
        })
      );
    }
    setQuestToDeleteFromLog(null);
    setIsDeleteQuestFromLogModalOpen(false);
  };

  const requestMarkQuestAsComplete = (quest) => {
    setQuestToMarkComplete(quest);
    setIsMarkCompleteModalOpen(true);
  };

  const confirmMarkQuestAsComplete = () => {
    if (questToMarkComplete) {
      handleUpdateQuestStatusOnMap(questToMarkComplete.id, 'Completed');
    }
    setQuestToMarkComplete(null);
    setIsMarkCompleteModalOpen(false);
  };


  const handleOpenLocationModal = (mode = 'create', locData = null) => {
    setLocationModalMode(mode);
    setEditingLocation(locData);
    setIsLocationModalOpen(true);
  };

  const handleLocationModalSubmit = (locDetails, action) => {
    if (action === 'delete' && editingLocation) {
      setLocationToDelete(editingLocation);
      setIsDeleteLocationModalOpen(true);
      setIsLocationModalOpen(false);
      return;
    }
    if (!locDetails) {
        setIsLocationModalOpen(false);
        setEditingLocation(null);
        return;
    }

    if (locationModalMode === 'create') {
      setPendingMarkerData({ ...locDetails, type: 'location', questIds: [] });
      setPlacingMarkerType('location');
    } else if (locationModalMode === 'edit' && editingLocation) {
      setMarkers(prevMarkers =>
        prevMarkers.map(marker =>
          marker.id === editingLocation.id ? { ...marker, ...locDetails } : marker
        )
      );
      setEditingLocation(null);
    }
    setIsLocationModalOpen(false);
  };

  const confirmActualLocationDelete = () => {
    if (locationToDelete) {
      setMarkers(prev => prev.filter(m => m.id !== locationToDelete.id));
    }
    setLocationToDelete(null);
    setIsDeleteLocationModalOpen(false);
  };

   const handleEditQuestFromLocation = (questToEdit) => {
    setIsLocationModalOpen(false);
    setEditingLocation(null);

    handleOpenQuestModal('edit', questToEdit);
  };

  const handleOpenPoiModal = (mode = 'create', poiData = null) => {
    setPoiModalMode(mode);
    setEditingPoi(poiData);
    setIsPoiModalOpen(true);
  };

  const handlePoiModalSubmit = (poiDetails, action) => {
    if (action === 'delete' && editingPoi) {
      setPoiToDelete(editingPoi);
      setIsDeletePoiModalOpen(true);
      setIsPoiModalOpen(false);
      return;
    }
    if (!poiDetails) {
        setIsPoiModalOpen(false);
        setEditingPoi(null);
        return;
    }

    if (poiModalMode === 'create') {
      setPendingMarkerData({ ...poiDetails, type: 'poi' });
      setPlacingMarkerType('poi');
    } else if (poiModalMode === 'edit' && editingPoi) {
      setMarkers(prevMarkers =>
        prevMarkers.map(marker =>
          marker.id === editingPoi.id ? { ...marker, ...poiDetails, type: 'poi' } : marker
        )
      );
      setEditingPoi(null);
    }
    setIsPoiModalOpen(false);
  };

  const confirmActualPoiDelete = () => {
    if (poiToDelete) {
      setMarkers(prev => prev.filter(m => m.id !== poiToDelete.id));
    }
    setPoiToDelete(null);
    setIsDeletePoiModalOpen(false);
  };

  const handleOpenSquadModal = (mode = 'create', squadData = null) => {
    setSquadModalMode(mode);
    setEditingSquad(squadData);
    setIsSquadModalOpen(true);
  };

  const handleSquadModalSubmit = (squadDetails, action) => {
    if (action === 'delete' && editingSquad) {
      setSquadToDelete(editingSquad);
      setIsDeleteSquadModalOpen(true);
      setIsSquadModalOpen(false);
      return;
    }
    if (!squadDetails) {
        setIsSquadModalOpen(false);
        setEditingSquad(null);
        return;
    }

    if (squadModalMode === 'create') {
      setPendingMarkerData({ ...squadDetails, type: 'squad' });
      setPlacingMarkerType('squad');
    } else if (squadModalMode === 'edit' && editingSquad) {
      setMarkers(prevMarkers =>
        prevMarkers.map(marker =>
          marker.id === editingSquad.id ? { ...marker, ...squadDetails, type: 'squad' } : marker
        )
      );
      setEditingSquad(null);
    }
    setIsSquadModalOpen(false);
  };

  const confirmActualSquadDelete = () => {
    if (squadToDelete) {
      setMarkers(prev => prev.filter(m => m.id !== squadToDelete.id));
    }
    setSquadToDelete(null);
    setIsDeleteSquadModalOpen(false);
  };

  const handleOpenJournal = () => {
    setIsJournalOpen(true);
  };

  const handleCloseJournal = () => {
    setIsJournalOpen(false);
  };

  const handleJournalOptionSelect = (option) => {
    console.log("Journal option selected:", option);
    setIsJournalOpen(false);
    if (option === 'quest_log') {
        alert('Quest Log selected! (Not implemented yet)');
    } else if (option === 'lore_book') {
        alert('Lore Book selected! (Not implemented yet)');
    }
  };

  const handleOpenLoreEntryModal = (mode = 'create', entryData = null, preselectedCategory = null) => {
    setLoreEntryModalMode(mode);
    setEditingLoreEntry(entryData);
    if (mode === 'create' && preselectedCategory) {
        setPreselectedCategoryForNewLore(preselectedCategory);
    } else {
        setPreselectedCategoryForNewLore(null);
    }
    setIsLoreEntryModalOpen(true);
  };

  const handleLoreEntryModalSubmit = (entryDetails) => {
    if (loreEntryModalMode === 'edit' && editingLoreEntry) {
      const updatedEntryId = editingLoreEntry.id;
      setLoreEntries(prev =>
        prev.map(entry =>
          entry.id === updatedEntryId ? { ...entry, ...entryDetails } : entry
        )
      );
    setIsLoreEntryModalOpen(false);
    setEditingLoreEntry(null);
    }

    if (loreEntryModalMode === 'create') {
      const newEntry = { id: generateLoreEntryId(), ...entryDetails };
      setLoreEntries(prev => [...prev, newEntry]);
    } else if (loreEntryModalMode === 'edit' && editingLoreEntry) {
      setLoreEntries(prev =>
        prev.map(entry =>
          entry.id === editingLoreEntry.id ? { ...entry, ...entryDetails } : entry
        )
      );
    }
    setIsLoreEntryModalOpen(false);
    setEditingLoreEntry(null);
  };

  const handleDeleteLoreEntry = (entryId) => {
    setLoreEntries(prev => prev.filter(entry => entry.id !== entryId));
  };

  const requestDeleteLoreEntry = (entry) => {
    setLoreEntryToDelete(entry);
    setIsDeleteLoreEntryModalOpen(true);
  };

  const confirmActualLoreEntryDelete = () => {
    if (loreEntryToDelete) {
      setLoreEntries(prev => prev.filter(entry => entry.id !== loreEntryToDelete.id));
    }
    setLoreEntryToDelete(null);
    setIsDeleteLoreEntryModalOpen(false);
  };

     const placeNewMarker = (xPercent, yPercent) => {
    if (!placingMarkerType || !pendingMarkerData) return;

    let targetLocationId = null;
    const newMarkerId = generateMarkerId();

    if (placingMarkerType === 'quest') {
      const markerHitRadiusPercent = 2.0;
      for (const marker of markers) {
        if (marker.type === 'location' && marker.x !== undefined && marker.y !== undefined) {
          const distX = Math.abs(marker.x - xPercent);
          const distY = Math.abs(marker.y - yPercent);
          if (distX < markerHitRadiusPercent && distY < markerHitRadiusPercent) {
            targetLocationId = marker.id;
            break;
          }
        }
      }
    }

    if (placingMarkerType === 'quest' && targetLocationId) {
      const newQuestDataForLocation = {
        id: newMarkerId,
        type: 'quest',
        ...pendingMarkerData,
      };

      setMarkers(prevMarkers => {
        const markersWithNewQuest = [...prevMarkers, newQuestDataForLocation];

        return markersWithNewQuest.map(m => {
          if (m.id === targetLocationId) {
            const currentQuestIds = m.questIds || [];
            if (!currentQuestIds.includes(newQuestDataForLocation.id)) {
              return { ...m, questIds: [...currentQuestIds, newQuestDataForLocation.id] };
            }
          }
          return m;
        });
      });
    } else {
      const newMarkerOnMap = {
        id: newMarkerId,
        ...pendingMarkerData,
        x: xPercent,
        y: yPercent,
      };
      if (placingMarkerType === 'location' && !newMarkerOnMap.questIds) {
        newMarkerOnMap.questIds = [];
      }
      setMarkers(prevMarkers => [...prevMarkers, newMarkerOnMap]);
    }

    setPlacingMarkerType(null);
    setPendingMarkerData(null);
  };

  const handleMarkerClick = (marker) => {
    if (placingMarkerType) {
      setPlacingMarkerType(null);
      setPendingMarkerData(null);
      return;
    }

    if (marker.type === 'quest') {
      handleOpenQuestModal('edit', marker);
    } else if (marker.type === 'location') {
      handleOpenLocationModal('edit', marker);
    } else if (marker.type === 'poi') {
      handleOpenPoiModal('edit', marker);
    }
    else if (marker.type === 'squad') handleOpenSquadModal('edit', marker);
  };

  const toggleToolbar = () => {
    setIsToolbarOpen(!isToolbarOpen);
  };

  const toolButtons = [
    { id: 'tool1', icon: <ToolIcon1 />, action: () => handleOpenSquadModal('create'), title: 'Create Squad' },
    { id: 'tool2', icon: <ToolIcon2 />, action: () => handleOpenPoiModal('create'), title: 'Create Point of Interest' },
    { id: 'tool3', icon: <ToolIcon3 />, action: () => handleOpenLocationModal('create'), title: 'Create Location' },
    { id: 'tool4', icon: <ToolIcon4 />, action: () => handleOpenQuestModal('create'), title: 'Create Quest'},
  ];

  if (!campaignData || !campaignData.mapImage) {
    return (
      <div className="campaign-editor-page" style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', color: 'white' }}>
        Loading campaign map or map not found...
      </div>
    );
  }

  const allQuestMarkers = markers.filter(marker => marker.type === 'quest');

  return (
    <div className="campaign-editor-page">
      <button onClick={() => navigate('/campaign-editor')}
                className="go-back-button editor-map-go-back"
                aria-label="Go back"
                title="Go back"
              >
                <BackArrowIcon />
              </button>
      <TransformWrapper
        initialScale={1} minScale={0.1} maxScale={10} limitToBounds={false}
        panning={{ velocityDisabled: true }} doubleClick={{ disabled: true }}
        onPanningStart={() => setIsPanning(true)} onPanningStop={() => setIsPanning(false)}
      >
        {({ zoomIn, zoomOut, setTransform, centerView, instance }) => (
          <>
            <TransformComponent
              wrapperStyle={{ width: '100%', height: '100%' }}
              contentStyle={{ width: 'auto', height: 'auto' }}
            >
              <MapInteractionWrapper
                scale={instance.transformState.scale}
                positionX={instance.transformState.positionX}
                positionY={instance.transformState.positionY}
                onMapClick={placingMarkerType ? placeNewMarker : undefined}
                mapContentRef={mapContentRef}
              >
                <div ref={mapContentRef} className={`map-container ${isPanning ? 'grabbing' : ''}`} style={{ position: 'relative', width: 'fit-content', height: 'fit-content' }}>
                  <img
                    src={campaignData.mapImage}
                    alt={`${campaignData.name} Map`}
                    style={{ display: 'block', maxWidth: '100%', maxHeight: '100%' }}
                    draggable="false"
                  />
                  {markers
                    .filter(marker => marker.x !== undefined && marker.y !== undefined)
                    .map(marker => (
                      <MapMarker
                        key={marker.id}
                        marker={marker}
                        onClick={handleMarkerClick}
                        scale={instance.transformState.scale}
                        allQuestsDataForIndicator={allMarkersData.filter(m => m.type === 'quest')}
                      />
                  ))}
                </div>
              </MapInteractionWrapper>
            </TransformComponent>
          </>
        )}
      </TransformWrapper>

      {placingMarkerType && pendingMarkerData && (
        <div
          className={placingMarkerType === 'squad' ? 'squad-cursor-follower' : 'cursor-follower-marker'}
          style={{ left: cursorFollowerPos.x, top: cursorFollowerPos.y }}
        >
          {placingMarkerType === 'quest' && <ToolIcon4 />}
          {placingMarkerType === 'location' && <ToolIcon3 />}
          {placingMarkerType === 'poi' && <ToolIcon2 />}
          {placingMarkerType === 'squad' && pendingMarkerData.image && (
            <img src={pendingMarkerData.image} alt="Placing squad" />
          )}
        </div>
      )}


      <div className="editor-toolbar">
        <div className="toolbar-button-group">
          {isToolbarOpen &&
            toolButtons.map((tool) => (
              <div key={tool.id} className={`tool-button-item ${isToolbarOpen ? '' : 'hidden'}`}>
                <button className="toolbar-button" onClick={tool.action} title={tool.title}>
                  {tool.icon}
                </button>
              </div>
            ))}
          <button className="toolbar-button" onClick={() => setIsToolbarOpen(!isToolbarOpen)} title={isToolbarOpen ? "Close tools" : "Open tools"}>
            {isToolbarOpen ? <MinusIcon /> : <PlusIcon />}
          </button>
        </div>
        <button className="toolbar-button" onClick={handleOpenJournal} title="Open Journal">
          <BookIcon />
        </button>
      </div>

      <QuestModal
        isOpen={isQuestModalOpen}
        onClose={() => {
            setIsQuestModalOpen(false);
            setEditingQuest(null);
        }}
        onSubmit={handleQuestModalSubmit}
        initialData={editingQuest}
        mode={questModalMode}
      />

       <LocationModal
        isOpen={isLocationModalOpen}
        onClose={() => {
            setIsLocationModalOpen(false);
            setEditingLocation(null);
        }}
        onSubmit={handleLocationModalSubmit}
        initialData={editingLocation}
        mode={locationModalMode}
        allQuests={markers.filter(m => m.type === 'quest')}
        onQuestClick={handleEditQuestFromLocation}
      />

      <PoiModal
        isOpen={isPoiModalOpen}
        onClose={() => { setIsPoiModalOpen(false); setEditingPoi(null); }}
        onSubmit={handlePoiModalSubmit}
        initialData={editingPoi}
        mode={poiModalMode}
      />

      <SquadModal
        isOpen={isSquadModalOpen}
        onClose={() => { setIsSquadModalOpen(false); setEditingSquad(null); }}
        onSubmit={handleSquadModalSubmit}
        initialData={editingSquad}
        mode={squadModalMode}
      />

        {isDeleteQuestModalOpen && questToDelete && (
            <div className="modal-overlay" onClick={() => setIsDeleteQuestModalOpen(false)}>
                <div className="modal-content" onClick={(e) => e.stopPropagation()}>
                    <h2>Delete Quest</h2>
                    <p style={{ textAlign: 'center', fontFamily: 'Arial, sans-serif', fontSize: '1.1em', marginBottom: '25px' }}>
                        Are you sure you want to delete the quest "{questToDelete.name}"?
                    </p>
                    <div className="modal-buttons">
                        <button type="button" className="modal-button cancel" onClick={() => setIsDeleteQuestModalOpen(false)}>
                            Cancel
                        </button>
                        <button type="button" className="modal-button delete" onClick={confirmActualQuestDelete}>
                            Delete
                        </button>
                    </div>
                </div>
            </div>
        )}

        {isDeleteLocationModalOpen && locationToDelete && (
        <div className="modal-overlay" onClick={() => setIsDeleteLocationModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>Delete Location</h2>
            <p style={{ textAlign: 'center', fontFamily: 'Arial, sans-serif', fontSize: '1.1em', marginBottom: '25px' }}>
              Are you sure you want to delete the location "{locationToDelete.name}"?
            </p>
            <div className="modal-buttons">
              <button type="button" className="modal-button cancel" onClick={() => setIsDeleteLocationModalOpen(false)}>Cancel</button>
              <button type="button" className="modal-button delete" onClick={confirmActualLocationDelete}>Delete</button>
            </div>
          </div>
        </div>
      )}
      {isDeletePoiModalOpen && poiToDelete && (
        <div className="modal-overlay" onClick={() => setIsDeletePoiModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>Delete Point of Interest</h2>
            <p style={{ textAlign: 'center', fontFamily: 'Arial, sans-serif', fontSize: '1.1em', marginBottom: '25px' }}>
              Are you sure you want to delete the Point of Interest "{poiToDelete.name}"?
            </p>
            <div className="modal-buttons">
              <button type="button" className="modal-button cancel" onClick={() => setIsDeletePoiModalOpen(false)}>Cancel</button>
              <button type="button" className="modal-button delete" onClick={confirmActualPoiDelete}>Delete</button>
            </div>
          </div>
        </div>
      )}
      {isDeleteSquadModalOpen && squadToDelete && (
        <div className="modal-overlay" onClick={() => setIsDeleteSquadModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>Delete Squad</h2>
            <p>Are you sure you want to delete the squad "{squadToDelete.name}"?</p>
            <div className="modal-buttons">
              <button type="button" className="modal-button cancel" onClick={() => setIsDeleteSquadModalOpen(false)}>Cancel</button>
              <button type="button" className="modal-button delete" onClick={confirmActualSquadDelete}>Delete</button>
            </div>
          </div>
        </div>
      )}
      <JournalOverlay
        isOpen={isJournalOpen}
        onClose={handleCloseJournal}
        loreEntries={loreEntries}
        onDeleteLoreEntryRequest={requestDeleteLoreEntry}
        onOpenLoreEntryModal={handleOpenLoreEntryModal}
        allMapMarkersForQuestLog={markers}
        onRequestCompleteQuest={requestMarkQuestAsComplete}
        onDeleteQuestFromLogRequest={requestDeleteQuestFromLog}
      />

      <LoreEntryModal
        isOpen={isLoreEntryModalOpen}
        onClose={() => { setIsLoreEntryModalOpen(false); setEditingLoreEntry(null); }}
        onSubmit={handleLoreEntryModalSubmit}
        initialData={editingLoreEntry || (preselectedCategoryForNewLore ? { category: preselectedCategoryForNewLore } : null)}
        mode={loreEntryModalMode}
      />

      {isDeleteLoreEntryModalOpen && loreEntryToDelete && (
        <div className="modal-overlay" onClick={() => setIsDeleteLoreEntryModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>Delete Lore Entry</h2>
            <p style={{ textAlign: 'center', fontFamily: 'Arial, sans-serif', fontSize: '1.1em', marginBottom: '25px' }}>
              Are you sure you want to delete the lore entry "{loreEntryToDelete.name}"?
            </p>
            <div className="modal-buttons">
              <button type="button" className="modal-button cancel" onClick={() => setIsDeleteLoreEntryModalOpen(false)}>
                Cancel
              </button>
              <button type="button" className="modal-button delete" onClick={confirmActualLoreEntryDelete}>
                Delete
              </button>
            </div>
          </div>
        </div>
      )}
      {isDeleteQuestFromLogModalOpen && questToDeleteFromLog && (
        <div className="modal-overlay" onClick={() => setIsDeleteQuestFromLogModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>Delete Quest from Log</h2>
            <p style={{ fontFamily: 'Arial, sans-serif' }} >Are you sure you want to permanently delete the completed quest "{questToDeleteFromLog.name}" from the Quest Log?</p>
            <div className="modal-buttons">
              <button type="button" className="modal-button cancel" onClick={() => setIsDeleteQuestFromLogModalOpen(false)}>Cancel</button>
              <button type="button" className="modal-button delete" onClick={confirmActualQuestFromLogDelete}>Delete</button>
            </div>
          </div>
        </div>
      )}
      {isMarkCompleteModalOpen && questToMarkComplete && (
        <div className="modal-overlay" onClick={() => setIsMarkCompleteModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>Mark Quest as Completed</h2>
            <p style={{ textAlign: 'center', fontFamily: 'Arial, sans-serif', fontSize: '1.1em', marginBottom: '25px' }}>
              Are you sure you want to mark the quest "{questToMarkComplete.name}" as Completed?
              This will remove its marker from the map.
            </p>
            <div className="modal-buttons">
              <button type="button" className="modal-button cancel" onClick={() => setIsMarkCompleteModalOpen(false)}>
                Cancel
              </button>
              <button type="button" className="modal-button confirm" onClick={confirmMarkQuestAsComplete}>
                Confirm
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default CampaignEditorMapPage;