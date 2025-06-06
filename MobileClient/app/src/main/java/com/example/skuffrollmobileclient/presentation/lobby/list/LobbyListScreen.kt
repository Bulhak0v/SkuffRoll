package com.example.skuffrollmobileclient.presentation.lobby.list

import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Add
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import com.example.skuffrollmobileclient.data.model.LobbyDto
import com.example.skuffrollmobileclient.ui.theme.SkuffRollTheme
import com.example.skuffrollmobileclient.ui.theme.InkBrown
import com.example.skuffrollmobileclient.ui.theme.Parchment
import com.example.skuffrollmobileclient.ui.theme.DarkerParchment
import com.example.skuffrollmobileclient.ui.theme.AccentGold
import com.example.skuffrollmobileclient.ui.theme.White

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun LobbyListScreen(
    viewModel: LobbyListViewModel = viewModel(),
    onLobbyClick: (Int) -> Unit,
    onCreateLobbyClick: () -> Unit
) {
    val uiState by viewModel.uiState.collectAsState()

    Scaffold(
        topBar = {
            CenterAlignedTopAppBar(
                title = { Text("My Lobbies", color = MaterialTheme.colorScheme.onPrimary) },
                colors = TopAppBarDefaults.centerAlignedTopAppBarColors(
                    containerColor = MaterialTheme.colorScheme.primaryContainer,
                    titleContentColor = MaterialTheme.colorScheme.onPrimaryContainer
                )
            )
        },
        floatingActionButton = {
            FloatingActionButton(
                onClick = onCreateLobbyClick,
                containerColor = MaterialTheme.colorScheme.secondary,
                contentColor = MaterialTheme.colorScheme.onSecondary
            ) {
                Icon(Icons.Filled.Add, "Create new lobby")
            }
        },
        modifier = Modifier.fillMaxSize()
    ) { paddingValues ->
        Column(
            modifier = Modifier
                .fillMaxSize()
                .padding(paddingValues)
                .background(MaterialTheme.colorScheme.background)
        ) {
            if (uiState.isLoading) {
                LinearProgressIndicator(
                    modifier = Modifier.fillMaxWidth(),
                    color = AccentGold
                )
            }

            uiState.errorMessage?.let { message ->
                Snackbar(
                    modifier = Modifier
                        .padding(16.dp)
                        .fillMaxWidth(),
                    action = {
                        TextButton(onClick = { viewModel.dismissError() }) {
                            Text("Dismiss", color = MaterialTheme.colorScheme.onError)
                        }
                    },
                    containerColor = MaterialTheme.colorScheme.error,
                    contentColor = MaterialTheme.colorScheme.onError
                ) { Text(message) }
            }

            if (!uiState.isLoading && uiState.lobbies.isEmpty() && uiState.errorMessage == null) {
                Column(
                    modifier = Modifier.fillMaxSize(),
                    horizontalAlignment = Alignment.CenterHorizontally,
                    verticalArrangement = Arrangement.Center
                ) {
                    Text(
                        text = "No lobbies found.\nCreate a new one or join an existing!",
                        style = MaterialTheme.typography.bodyLarge,
                        color = MaterialTheme.colorScheme.onBackground.copy(alpha = 0.7f),
                        modifier = Modifier.padding(16.dp)
                    )
                    Button(onClick = { viewModel.fetchLobbies() }) {
                        Text("Try again")
                    }
                }
            } else {
                LazyColumn(
                    modifier = Modifier
                        .fillMaxSize()
                        .padding(horizontal = 16.dp, vertical = 8.dp),
                    verticalArrangement = Arrangement.spacedBy(8.dp)
                ) {
                    items(uiState.lobbies) { lobby ->
                        LobbyItem(lobby = lobby, onClick = { onLobbyClick(lobby.id) })
                    }
                }
            }
        }
    }
}

@Composable
fun LobbyItem(lobby: LobbyDto, onClick: () -> Unit) {
    Card(
        modifier = Modifier
            .fillMaxWidth()
            .clickable(onClick = onClick),
        colors = CardDefaults.cardColors(
            containerColor = MaterialTheme.colorScheme.surface,
            contentColor = MaterialTheme.colorScheme.onSurface
        ),
        elevation = CardDefaults.cardElevation(defaultElevation = 2.dp)
    ) {
        Column(
            modifier = Modifier.padding(16.dp)
        ) {
            Text(
                text = lobby.name,
                style = MaterialTheme.typography.titleMedium,
                color = MaterialTheme.colorScheme.onSurface,
                modifier = Modifier.padding(bottom = 4.dp)
            )
            lobby.hostId?.let {
                Text(
                    text = "Game Master ID: $it",
                    style = MaterialTheme.typography.bodySmall,
                    color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.8f)
                )
            }
            lobby.campaignId?.let {
                Text(
                    text = "Campaign ID: $it",
                    style = MaterialTheme.typography.bodySmall,
                    color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.8f)
                )
            }
        }
    }
}

@Preview(showBackground = true)
@Composable
fun PreviewLobbyListScreen() {
    SkuffRollTheme {
        LobbyListScreen(
            onLobbyClick = { lobbyId -> println("Lobby clicked: $lobbyId") },
            onCreateLobbyClick = { println("Create Lobby clicked") }
        )
    }
}