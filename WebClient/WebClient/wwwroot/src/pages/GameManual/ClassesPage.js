import React from 'react';
import DetailPageLayout from '../../components/DetailPageLayout';
import ClassesContent from './ClassesContent';

const ClassesPage = () => {
  return (
    <DetailPageLayout pageTitle="Classes" backLink="/game-manual">
      <ClassesContent />
    </DetailPageLayout>
  );
};

export default ClassesPage;