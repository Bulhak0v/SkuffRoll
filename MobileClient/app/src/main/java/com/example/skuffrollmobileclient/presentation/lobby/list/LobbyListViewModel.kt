package com.example.skuffrollmobileclient.presentation.lobby.list

import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.skuffrollmobileclient.data.model.LobbyDto
import kotlinx.coroutines.delay
import kotlinx.coroutines.flow.MutableStateFlow
import kotlinx.coroutines.flow.StateFlow
import kotlinx.coroutines.flow.asStateFlow
import kotlinx.coroutines.launch

class LobbyListViewModel(
) : ViewModel() {

    private val _uiState = MutableStateFlow(LobbyListUiState())
    val uiState: StateFlow<LobbyListUiState> = _uiState.asStateFlow()

    init {
        fetchLobbies()
    }

    fun fetchLobbies() {
        viewModelScope.launch {
            _uiState.value = _uiState.value.copy(isLoading = true, errorMessage = null)
            try {
                delay(2000)

                val sampleLobbies = listOf(
                    LobbyDto(
                        id = 1,
                        name = "Journey to the Forgotten Lands",
                        hostId = 101,
                        campaignId = 1001
                    ),
                    LobbyDto(
                        id = 2,
                        name = "Mysteries of the Moonlight World",
                        hostId = 102,
                        campaignId = null
                    ),
                    LobbyDto(
                        id = 3,
                        name = "Adventures in the Silver League",
                        hostId = 103,
                        campaignId = 1002
                    ),
                    LobbyDto(
                        id = 4,
                        name = "Quest in Raven's Cove",
                        hostId = 101,
                        campaignId = null
                    )
                )
                _uiState.value = _uiState.value.copy(lobbies = sampleLobbies, isLoading = false)

            } catch (e: Exception) {
                _uiState.value = _uiState.value.copy(
                    errorMessage = "Failed to load lobbies: ${e.localizedMessage}",
                    isLoading = false
                )
            }
        }
    }

    fun dismissError() {
        _uiState.value = _uiState.value.copy(errorMessage = null)
    }
}