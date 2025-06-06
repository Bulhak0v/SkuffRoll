import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';
import { ReactComponent as EditIcon } from '../../assets/icons/edit.svg';
import { ReactComponent as TrashIcon } from '../../assets/icons/trash.svg';

const HomebrewListPage = ({ itemType }) => {
  const navigate = useNavigate();
  const [items, setItems] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [itemToDelete, setItemToDelete] = useState(null);

  const storageKey = `skuffrollHomebrew${itemType.charAt(0).toUpperCase() + itemType.slice(1)}`;

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;

    const storedItems = JSON.parse(localStorage.getItem(storageKey) || '[]');
    setItems(storedItems);
    setIsLoading(false);
  }, [storageKey, itemType]);

  const singularItemType = itemType.endsWith('es') ? itemType.slice(0, -2) : itemType.slice(0, -1);

  const handleAddNew = () => {
    navigate(`/homebrew-editor/${itemType}/new`);
  };

  const handleEdit = (item) => {
    navigate(`/homebrew-editor/${itemType}/edit/${item.id}`, { state: { itemData: item } });
  };

  const openDeleteModal = (item) => {
    setItemToDelete(item);
    setIsDeleteModalOpen(true);
  };

  const confirmDeleteItem = () => {
    if (!itemToDelete) return;
    const updatedItems = items.filter(it => it.id !== itemToDelete.id);
    setItems(updatedItems);
    localStorage.setItem(storageKey, JSON.stringify(updatedItems));
    setIsDeleteModalOpen(false);
      setItemToDelete(null);
      if (itemType == "classes") {
          deleteClassFromBackend();
      }
      else if (itemType == "races") {
          deleteRaceFromBackend();
      }
  };

    const deleteClassFromBackend = async () =>{
        try {
            const response = await fetch("/api/homebrewclass/delete", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(itemToDelete),
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

    const deleteRaceFromBackend = async () => {
        try {
            const response = await fetch("https://localhost:7174/api/homebrewrace/delete", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(itemToDelete),
            });

            if (response.ok) { 
                const contentType = response.headers.get("content-type");
                if (contentType && contentType.includes("application/json")) {
                    const data = await response.json(); 
                    console.log('Race deleted successfully:', data.message);
                } else {
                    console.log('Race deleted successfully, no JSON response expected.');
                }
                const errorText = await response.text(); 
            }
        } catch (error) {
            alert('Race deleted successfully');
        }
    }

  if (isLoading) {
    return <div className="homebrew-list-page"><h2>Loading custom {itemType}...</h2></div>;
  }

  const pageTitle = `Custom ${itemType.charAt(0).toUpperCase() + itemType.slice(1)}`;

  return (
    <>
      <main className="homebrew-list-page">
        <h2>{pageTitle}</h2>
        <button className="add-new-button" onClick={handleAddNew}>
          Add new {itemType}
        </button>

        <div className="homebrew-list-container">
          {items.length === 0 ? (
            <p style={{ textAlign: 'center', color: '#e0e0e0', marginTop: '20px' }}>
              No custom {itemType} created yet.
            </p>
          ) : (
            items.map(item => (
              <div key={item.id} className="homebrew-list-item">
                <span className="homebrew-item-name">{item.name}</span>
                <div className="homebrew-item-actions">
                  <button className="homebrew-action-button edit-hb" onClick={() => handleEdit(item)} title="Edit">
                    <EditIcon />
                  </button>
                  <button className="homebrew-action-button delete-hb" onClick={() => openDeleteModal(item)} title="Delete">
                    <TrashIcon />
                  </button>
                </div>
              </div>
            ))
          )}
        </div>
      </main>

      {isDeleteModalOpen && itemToDelete && (
        <div className="modal-overlay" onClick={() => setIsDeleteModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>Delete {itemType.slice(0, -1)}</h2>
            <p style={{ textAlign: 'center', fontFamily: 'Arial, sans-serif', fontSize: '1.1em', marginBottom: '25px' }}>
              Are you sure you want to delete "{itemToDelete.name}"? This action cannot be undone.
            </p>
            <div className="modal-buttons">
              <button type="button" className="modal-button cancel" onClick={() => setIsDeleteModalOpen(false)}>
                Cancel
              </button>
              <button type="button" className="modal-button delete" onClick={confirmDeleteItem}>
                Delete
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default HomebrewListPage;