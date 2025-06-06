package com.example.skuffrollmobileclient.presentation.event.detail

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.automirrored.filled.ArrowBack
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.runtime.collectAsState
import androidx.compose.runtime.getValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import com.example.skuffrollmobileclient.data.model.EventDto
import com.example.skuffrollmobileclient.ui.theme.SkuffRollTheme
import com.example.skuffrollmobileclient.ui.theme.AccentGold
import com.example.skuffrollmobileclient.ui.theme.InkBrown

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun EventDetailScreen(
    viewModel: EventDetailViewModel = viewModel(),
    onBackClick: () -> Unit
) {
    val uiState by viewModel.uiState.collectAsState()

    Scaffold(
        topBar = {
            CenterAlignedTopAppBar(
                title = { Text(uiState.event?.name ?: "Event Details", color = MaterialTheme.colorScheme.onPrimary) },
                navigationIcon = {
                    IconButton(onClick = onBackClick) {
                        Icon(Icons.AutoMirrored.Filled.ArrowBack, contentDescription = "Back")
                    }
                },
                colors = TopAppBarDefaults.centerAlignedTopAppBarColors(
                    containerColor = MaterialTheme.colorScheme.primaryContainer,
                    titleContentColor = MaterialTheme.colorScheme.onPrimaryContainer
                )
            )
        },
        modifier = Modifier.fillMaxSize()
    ) { paddingValues ->
        Column(
            modifier = Modifier
                .fillMaxSize()
                .padding(paddingValues)
                .background(MaterialTheme.colorScheme.background),
            horizontalAlignment = Alignment.CenterHorizontally,
            verticalArrangement = Arrangement.Center
        ) {
            if (uiState.isLoading) {
                CircularProgressIndicator(color = AccentGold, modifier = Modifier.size(48.dp))
                Spacer(modifier = Modifier.height(16.dp))
                Text("Loading event details...", color = InkBrown)
            }

            uiState.errorMessage?.let { message ->
                Snackbar(
                    modifier = Modifier
                        .padding(bottom = 16.dp)
                        .fillMaxWidth(),
                    action = {
                        TextButton(onClick = { viewModel.dismissError() }) {
                            Text("Dismiss", color = MaterialTheme.colorScheme.onError)
                        }
                    },
                    containerColor = MaterialTheme.colorScheme.error,
                    contentColor = MaterialTheme.colorScheme.onError
                ) { Text(message) }
                Spacer(modifier = Modifier.height(16.dp))
            }

            uiState.event?.let { event ->
                EventDetailsCard(event = event)
            } ?: run {
                if (!uiState.isLoading && uiState.errorMessage == null) {
                    Text(
                        text = "Event details could not be loaded.",
                        style = MaterialTheme.typography.bodyLarge,
                        color = InkBrown.copy(alpha = 0.7f)
                    )
                }
            }
        }
    }
}

@Composable
fun EventDetailsCard(event: EventDto) {
    Card(
        modifier = Modifier
            .fillMaxWidth(0.9f)
            .padding(16.dp),
        colors = CardDefaults.cardColors(
            containerColor = MaterialTheme.colorScheme.surface,
            contentColor = MaterialTheme.colorScheme.onSurface
        ),
        elevation = CardDefaults.cardElevation(defaultElevation = 4.dp)
    ) {
        Column(modifier = Modifier.padding(20.dp)) {
            Text(
                text = event.name,
                style = MaterialTheme.typography.headlineMedium,
                color = InkBrown,
                modifier = Modifier.padding(bottom = 8.dp)
            )
            Divider(color = MaterialTheme.colorScheme.outline, thickness = 1.dp, modifier = Modifier.padding(vertical = 4.dp))
            event.campaignId?.let {
                Text(
                    text = "Campaign ID: $it",
                    style = MaterialTheme.typography.titleMedium,
                    color = InkBrown.copy(alpha = 0.8f),
                    modifier = Modifier.padding(bottom = 4.dp)
                )
            }
            event.description?.let {
                Text(
                    text = "Description:",
                    style = MaterialTheme.typography.titleMedium,
                    color = InkBrown.copy(alpha = 0.8f)
                )
                Text(
                    text = it,
                    style = MaterialTheme.typography.bodyLarge,
                    color = InkBrown,
                    modifier = Modifier.padding(bottom = 8.dp)
                )
            }
            event.icon?.let {
                Text(
                    text = "Icon: $it",
                    style = MaterialTheme.typography.titleMedium,
                    color = InkBrown.copy(alpha = 0.8f),
                    modifier = Modifier.padding(bottom = 4.dp)
                )
            }
            event.xCoordinate?.let { x ->
                event.yCoordinate?.let { y ->
                    Text(
                        text = "Coordinates: X: %.2f, Y: %.2f".format(x, y),
                        style = MaterialTheme.typography.bodyLarge,
                        color = InkBrown
                    )
                }
            }
        }
    }
}

@Preview(showBackground = true)
@Composable
fun PreviewEventDetailScreen() {
    SkuffRollTheme {
        EventDetailScreen(onBackClick = {})
    }
}

@Preview(showBackground = true)
@Composable
fun PreviewEventDetailsCard() {
    SkuffRollTheme {
        val sampleEvent = EventDto(
            id = 1,
            campaignId = 101,
            name = "Preview Event",
            description = "This is a detailed description of a preview event to show how it looks.",
            icon = "preview_icon",
            xCoordinate = 0.5,
            yCoordinate = 0.5
        )
        EventDetailsCard(event = sampleEvent)
    }
}
