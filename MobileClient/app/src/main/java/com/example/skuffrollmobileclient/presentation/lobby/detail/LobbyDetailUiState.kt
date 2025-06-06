package com.example.skuffrollmobileclient.presentation.lobby.detail

import com.example.skuffrollmobileclient.data.model.LobbyDto
import com.example.skuffrollmobileclient.data.model.MessageDto
import com.example.skuffrollmobileclient.data.model.UserDto

data class LobbyDetailUiState(
    val isLoading: Boolean = false,
    val lobby: LobbyDto? = null,
    val players: List<UserDto> = emptyList(),
    val chatMessages: List<MessageDto> = emptyList(),
    val errorMessage: String? = null,
    val currentSelectedTab: Int = 0
)