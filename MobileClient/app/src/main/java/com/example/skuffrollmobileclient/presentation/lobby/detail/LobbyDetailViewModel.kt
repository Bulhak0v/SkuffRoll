package com.example.skuffrollmobileclient.presentation.lobby.detail

import androidx.lifecycle.SavedStateHandle
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.skuffrollmobileclient.data.model.LobbyDto
import com.example.skuffrollmobileclient.data.model.MessageDto
import com.example.skuffrollmobileclient.data.model.UserDto
import kotlinx.coroutines.delay
import kotlinx.coroutines.flow.MutableStateFlow
import kotlinx.coroutines.flow.StateFlow
import kotlinx.coroutines.flow.asStateFlow
import kotlinx.coroutines.flow.update
import kotlinx.coroutines.launch
import java.util.Date
import java.util.UUID

const val LOBBY_ID_ARG = "lobbyId"

class LobbyDetailViewModel(
    savedStateHandle: SavedStateHandle
) : ViewModel() {

    private val _uiState = MutableStateFlow(LobbyDetailUiState())
    val uiState: StateFlow<LobbyDetailUiState> = _uiState.asStateFlow()

    private val lobbyId: Int? = savedStateHandle[LOBBY_ID_ARG]

    init {
        lobbyId?.let { id ->
            fetchLobbyDetails(id)
            fetchPlayers(id)
            fetchChatMessages(id)
        } ?: run {
            _uiState.update { it.copy(errorMessage = "Lobby ID not provided.") }
        }
    }

    fun fetchLobbyDetails(id: Int) {
        viewModelScope.launch {
            _uiState.update { it.copy(isLoading = true, errorMessage = null) }
            try {
                delay(1500)

                val sampleLobbies = listOf(
                    LobbyDto(id = 1, name = "Journey to the Forgotten Lands", hostId = 101, campaignId = 1001),
                    LobbyDto(id = 2, name = "Mysteries of the Moonlight World", hostId = 102, campaignId = null),
                    LobbyDto(id = 3, name = "Adventures in the Silver League", hostId = 103, campaignId = 1002)
                )
                val foundLobby = sampleLobbies.find { it.id == id }

                _uiState.update { currentState ->
                    if (foundLobby != null) {
                        currentState.copy(lobby = foundLobby, isLoading = false)
                    } else {
                        currentState.copy(errorMessage = "Lobby with ID $id not found.", isLoading = false)
                    }
                }
            } catch (e: Exception) {
                _uiState.update { currentState ->
                    currentState.copy(
                        errorMessage = "Failed to load lobby details: ${e.localizedMessage}",
                        isLoading = false
                    )
                }
            }
        }
    }

    fun fetchPlayers(lobbyId: Int) {
        viewModelScope.launch {
            try {
                delay(1000)

                val sampleUsers = when (lobbyId) {
                    1 -> listOf(
                        UserDto(id = 101, login = "Gandalf", password = "hashed_password", email = "gandalf@example.com", registrationDate = Date()),
                        UserDto(id = 104, login = "Aragorn", password = "hashed_password", email = "aragorn@example.com", registrationDate = Date()),
                        UserDto(id = 105, login = "Legolas", password = "hashed_password", email = "legolas@example.com", registrationDate = Date())
                    )
                    2 -> listOf(
                        UserDto(id = 102, login = "Luna", password = "hashed_password", email = "luna@example.com", registrationDate = Date()),
                        UserDto(id = 106, login = "Silas", password = "hashed_password", email = "silas@example.com", registrationDate = Date())
                    )
                    else -> emptyList()
                }
                _uiState.update { it.copy(players = sampleUsers) }

            } catch (e: Exception) {
                _uiState.update { currentState ->
                    currentState.copy(
                        errorMessage = "Failed to load players: ${e.localizedMessage}"
                    )
                }
            }
        }
    }

    fun fetchChatMessages(lobbyId: Int) {
        viewModelScope.launch {
            try {
                delay(1000)

                val initialMessages = when (lobbyId) {
                    1 -> listOf(
                        MessageDto(id = 1, userId = 101, creationDate = Date(System.currentTimeMillis() - 60000), messageContent = "Welcome, adventurers!"),
                        MessageDto(id = 2, userId = 104, creationDate = Date(System.currentTimeMillis() - 30000), messageContent = "Ready for the journey.")
                    )
                    2 -> listOf(
                        MessageDto(id = 3, userId = 102, creationDate = Date(System.currentTimeMillis() - 90000), messageContent = "Hello everyone, let's explore the moon!")
                    )
                    else -> emptyList()
                }
                _uiState.update { it.copy(chatMessages = initialMessages) }

            } catch (e: Exception) {
                _uiState.update { currentState ->
                    currentState.copy(
                        errorMessage = "Failed to load chat messages: ${e.localizedMessage}"
                    )
                }
            }
        }
    }

    fun sendChatMessage(message: String) {
        if (message.isBlank()) return

        val senderUserId = 999
        val newId = (_uiState.value.chatMessages.maxOfOrNull { it.id } ?: 0) + 1

        val newMessage = MessageDto(
            id = newId,
            userId = senderUserId,
            creationDate = Date(),
            messageContent = message
        )

        _uiState.update { currentState ->
            currentState.copy(
                chatMessages = currentState.chatMessages + newMessage
            )
        }
    }

    fun dismissError() {
        _uiState.update { it.copy(errorMessage = null) }
    }

    fun setSelectedTab(index: Int) {
        _uiState.update { it.copy(currentSelectedTab = index) }
    }
}