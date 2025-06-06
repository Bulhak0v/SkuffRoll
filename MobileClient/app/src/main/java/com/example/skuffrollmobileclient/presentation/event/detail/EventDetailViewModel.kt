package com.example.skuffrollmobileclient.presentation.event.detail

import androidx.lifecycle.SavedStateHandle
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.skuffrollmobileclient.data.model.EventDto
import kotlinx.coroutines.delay
import kotlinx.coroutines.flow.MutableStateFlow
import kotlinx.coroutines.flow.StateFlow
import kotlinx.coroutines.flow.asStateFlow
import kotlinx.coroutines.flow.update
import kotlinx.coroutines.launch
import java.util.Date

const val EVENT_ID_ARG = "eventId"

data class EventDetailUiState(
    val event: EventDto? = null,
    val isLoading: Boolean = false,
    val errorMessage: String? = null
)

class EventDetailViewModel(
    savedStateHandle: SavedStateHandle
) : ViewModel() {

    private val _uiState = MutableStateFlow(EventDetailUiState())
    val uiState: StateFlow<EventDetailUiState> = _uiState.asStateFlow()

    private val eventId: Int? = savedStateHandle[EVENT_ID_ARG]

    init {
        eventId?.let { id ->
            fetchEventDetails(id)
        } ?: run {
            _uiState.update { it.copy(errorMessage = "Event ID not provided.") }
        }
    }

    fun fetchEventDetails(id: Int) {
        viewModelScope.launch {
            _uiState.update { it.copy(isLoading = true, errorMessage = null) }
            try {
                delay(1000) // Simulate network request delay

                val sampleEvents = listOf(
                    EventDto(
                        id = 1,
                        campaignId = 101,
                        name = "Goblin Ambush",
                        description = "A horde of goblins ambushed a trading caravan near the Whispering Woods. Adventurers needed!",
                        icon = "goblin_icon", // Додано icon
                        xCoordinate = 0.3, // Оновлено
                        yCoordinate = 0.2
                    ),
                    EventDto(
                        id = 2,
                        campaignId = 101,
                        name = "Mysterious Lights",
                        description = "Strange lights observed in the Dragon's Peak mountains. Locals report eerie sounds.",
                        icon = "light_icon", // Додано icon
                        xCoordinate = 0.7, // Оновлено
                        yCoordinate = 0.5
                    ),
                    EventDto(
                        id = 3,
                        campaignId = 101,
                        name = "Missing Artifact",
                        description = "The ancient Amulet of Thror has been stolen from the city vaults. Reward offered for its return.",
                        icon = "artifact_icon", // Додано icon
                        xCoordinate = 0.1, // Оновлено
                        yCoordinate = 0.8
                    )
                )
                val foundEvent = sampleEvents.find { it.id == id }

                _uiState.update { currentState ->
                    if (foundEvent != null) {
                        currentState.copy(event = foundEvent, isLoading = false)
                    } else {
                        currentState.copy(errorMessage = "Event with ID $id not found.", isLoading = false)
                    }
                }
            } catch (e: Exception) {
                _uiState.update { currentState ->
                    currentState.copy(
                        errorMessage = "Failed to load event details: ${e.localizedMessage}",
                        isLoading = false
                    )
                }
            }
        }
    }

    fun dismissError() {
        _uiState.update { it.copy(errorMessage = null) }
    }
}