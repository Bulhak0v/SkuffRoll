package com.example.skuffrollmobileclient.presentation.lobby.list

import com.example.skuffrollmobileclient.data.model.LobbyDto

data class LobbyListUiState(
    val isLoading: Boolean = false,
    val lobbies: List<LobbyDto> = emptyList(),
    val errorMessage: String? = null
)