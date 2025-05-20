import React from 'react';
import { BrowserRouter as Router, Routes, Route, useLocation } from 'react-router-dom';
import './App.css';

import Header from './components/Header';
import HomepageFooter from './components/HomepageFooter';
import CopyrightFooter from './components/CopyrightFooter';
import Homepage from './pages/Homepage';
import GameManualPage from './pages/GameManual/GameManualPage';
import RacesPage from './pages/GameManual/RacesPage';
import ClassesPage from './pages/GameManual/ClassesPage';
import PersonalityBackgroundPage from './pages/GameManual/PersonalityBackgroundPage';
import CampaignSlotsPage from './pages/CampaignEditor/CampaignSlotsPage';
import CampaignEditorMapPage from './pages/CampaignEditor/CampaignEditorMapPage';
import LobbyManagementPage from './pages/LobbyManagement/LobbyManagementPage';
import CreateLobbyPage from './pages/LobbyManagement/CreateLobbyPage';
import LobbySuccessPage from './pages/LobbyManagement/LobbySuccessPage';
import EditLobbyListPage from './pages/LobbyManagement/EditLobbyListPage';
import CharacterCreationPage1 from './pages/CharacterCreation/CharacterCreationPage1';
import CharacterCreationPage2 from './pages/CharacterCreation/CharacterCreationPage2';
import CharacterCreationPage3 from './pages/CharacterCreation/CharacterCreationPage3';
import CharacterCreationPage4 from './pages/CharacterCreation/CharacterCreationPage4';
import CharacterCreationPage5 from './pages/CharacterCreation/CharacterCreationPage5';
import CharacterCreationPage6 from './pages/CharacterCreation/CharacterCreationPage6';
import CharacterCreationSummary from './pages/CharacterCreation/CharacterCreationSummary';
import CharacterManagementPage from './pages/CharacterManager/CharacterManagementPage';
import DevelopmentTreePage from './pages/CharacterManager/DevelopmentTreePage';
import UserProfilePage from './pages/Profile/UserProfilePage';
import LobbyViewPage from './pages/LobbyManagement/LobbyViewPage';
import HomebrewEditorMainPage from './pages/HomebrewEditor/HomebrewEditorMainPage';
import HomebrewListPage from './pages/HomebrewEditor/HomebrewListPage';
import CreateEditHomebrewClassPage from './pages/HomebrewEditor/CreateEditHomebrewClassPage';
import CreateEditHomebrewRacePage from './pages/HomebrewEditor/CreateEditHomebrewRacePage';

const AppLayout = () => {
  const location = useLocation();
  const isHomepage = location.pathname === '/';
  return (
    <div className="app-container">
      <Header />
      <Routes>
        <Route path="/" element={<Homepage />} />
        <Route path="/game-manual" element={<GameManualPage />} />
        <Route path="/game-manual/races" element={<RacesPage />} />
        <Route path="/game-manual/classes" element={<ClassesPage />} />
        <Route path="/game-manual/personality-background" element={<PersonalityBackgroundPage />} />
        <Route path="/character-management" element={<CharacterManagementPage />} />
        <Route path="/character-creation" element={<CharacterCreationPage1 />} />
        <Route path="/character-creation/step2" element={<CharacterCreationPage2 />} />
        <Route path="/character-creation/step3" element={<CharacterCreationPage3 />} />
        <Route path="/character-creation/step4" element={<CharacterCreationPage4 />} />
        <Route path="/character-creation/step5" element={<CharacterCreationPage5 />} />
        <Route path="/character-creation/step6" element={<CharacterCreationPage6 />} />
        <Route path="/character-creation/summary" element={<CharacterCreationSummary />} />
        <Route path="/character-development-tree" element={<DevelopmentTreePage />} />
        <Route path="/lobby-management" element={<LobbyManagementPage />} />
        <Route path="/lobby-management/create" element={<CreateLobbyPage />} />
        <Route path="/lobby-management/success" element={<LobbySuccessPage />} />
        <Route path="/lobby-management/edit" element={<EditLobbyListPage />} />
        <Route path="/lobby-management/view/:lobbyId" element={<LobbyViewPage />} />
        <Route path="/homebrew-editor" element={<HomebrewEditorMainPage />} />
        <Route path="/homebrew-editor/classes" element={<HomebrewListPage itemType="classes" />} />
        <Route path="/homebrew-editor/races" element={<HomebrewListPage itemType="races" />} />
        <Route path="/homebrew-editor/races/new" element={<CreateEditHomebrewRacePage mode="create" />} />
        <Route path="/homebrew-editor/races/edit/:itemId" element={<CreateEditHomebrewRacePage mode="edit" />} />
        <Route path="/homebrew-editor/classes/new" element={<CreateEditHomebrewClassPage mode="create" />} />
        <Route path="/homebrew-editor/classes/edit/:itemId" element={<CreateEditHomebrewClassPage mode="edit" />} />
        <Route path="/campaign-editor" element={<CampaignSlotsPage />} />
        <Route path="/campaign-editor/:campaignId" element={<CampaignEditorMapPage />} />
        <Route path="/profile" element={<UserProfilePage />} />

        <Route path="/game-manual/races" element={<div>Races Detail Page</div>} />
        <Route path="/game-manual/classes" element={<div>Classes Detail Page</div>} />
        <Route path="/game-manual/personality-background" element={<div>Personality & Background Detail Page</div>} />
      </Routes>
      {isHomepage ? <HomepageFooter /> : <CopyrightFooter />}
    </div>
  );
}

function App() {
  return (
    <Router>
      <AppLayout />
    </Router>
  );
}

export default App;