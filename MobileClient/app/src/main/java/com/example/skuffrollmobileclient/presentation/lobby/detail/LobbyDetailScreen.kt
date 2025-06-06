package com.example.skuffrollmobileclient.presentation.lobby.detail

import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.gestures.detectTransformGestures
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.automirrored.filled.ArrowBack
import androidx.compose.material.icons.filled.Send
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.runtime.collectAsState
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.graphicsLayer
import androidx.compose.ui.input.pointer.pointerInput
import androidx.compose.ui.layout.onSizeChanged
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.ImeAction
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import com.example.skuffrollmobileclient.R
import com.example.skuffrollmobileclient.data.model.LobbyDto
import com.example.skuffrollmobileclient.data.model.MessageDto
import com.example.skuffrollmobileclient.data.model.UserDto
import com.example.skuffrollmobileclient.data.model.EventDto
import com.example.skuffrollmobileclient.ui.theme.SkuffRollTheme
import com.example.skuffrollmobileclient.ui.theme.AccentGold
import com.example.skuffrollmobileclient.ui.theme.InkBrown
import com.example.skuffrollmobileclient.ui.theme.Parchment
import com.example.skuffrollmobileclient.ui.theme.DarkerParchment
import java.text.SimpleDateFormat
import java.util.Date
import java.util.Locale

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun LobbyDetailScreen(
    viewModel: LobbyDetailViewModel = viewModel(),
    onBackClick: () -> Unit,
    onEventClick: (eventId: Int) -> Unit
) {
    val uiState by viewModel.uiState.collectAsState()
    val tabs = listOf("Details", "Players", "Chat", "Map")

    Scaffold(
        topBar = {
            CenterAlignedTopAppBar(
                title = { Text(uiState.lobby?.name ?: "Lobby Details", color = MaterialTheme.colorScheme.onPrimary) },
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
                .background(MaterialTheme.colorScheme.background)
        ) {
            TabRow(
                selectedTabIndex = uiState.currentSelectedTab,
                containerColor = MaterialTheme.colorScheme.primaryContainer,
                contentColor = MaterialTheme.colorScheme.onPrimaryContainer
            ) {
                tabs.forEachIndexed { index, title ->
                    Tab(
                        selected = uiState.currentSelectedTab == index,
                        onClick = { viewModel.setSelectedTab(index) },
                        text = { Text(title) }
                    )
                }
            }

            when (uiState.currentSelectedTab) {
                0 -> DetailsTabContent(uiState = uiState, viewModel = viewModel)
                1 -> PlayersTabContent(uiState = uiState, viewModel = viewModel)
                2 -> ChatTabContent(uiState = uiState, viewModel = viewModel)
                3 -> MapTabContent(onEventClick = onEventClick)
            }
        }
    }
}

@Composable
fun DetailsTabContent(uiState: LobbyDetailUiState, viewModel: LobbyDetailViewModel) {
    Column(
        modifier = Modifier
            .fillMaxSize()
            .padding(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        if (uiState.isLoading) {
            CircularProgressIndicator(color = AccentGold, modifier = Modifier.size(48.dp))
            Spacer(modifier = Modifier.height(16.dp))
            Text("Loading lobby details...", color = InkBrown)
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

        uiState.lobby?.let { lobby ->
            LobbyDetailCard(lobby = lobby)
        } ?: run {
            if (!uiState.isLoading && uiState.errorMessage == null) {
                Text(
                    text = "Lobby details could not be loaded.",
                    style = MaterialTheme.typography.bodyLarge,
                    color = InkBrown.copy(alpha = 0.7f)
                )
            }
        }
    }
}

@Composable
fun LobbyDetailCard(lobby: LobbyDto) {
    Card(
        modifier = Modifier
            .fillMaxWidth()
            .padding(vertical = 8.dp),
        colors = CardDefaults.cardColors(
            containerColor = MaterialTheme.colorScheme.surface,
            contentColor = MaterialTheme.colorScheme.onSurface
        ),
        elevation = CardDefaults.cardElevation(defaultElevation = 4.dp)
    ) {
        Column(modifier = Modifier.padding(16.dp)) {
            Text(
                text = lobby.name,
                style = MaterialTheme.typography.headlineSmall,
                color = InkBrown,
                modifier = Modifier.padding(bottom = 8.dp)
            )
            Divider(color = DarkerParchment, thickness = 1.dp, modifier = Modifier.padding(vertical = 4.dp))
            Row(modifier = Modifier.fillMaxWidth(), horizontalArrangement = Arrangement.SpaceBetween) {
                Text(
                    text = "Lobby ID:",
                    style = MaterialTheme.typography.bodyLarge,
                    color = InkBrown.copy(alpha = 0.8f)
                )
                Text(
                    text = "${lobby.id}",
                    style = MaterialTheme.typography.bodyLarge,
                    color = InkBrown
                )
            }
            Spacer(modifier = Modifier.height(4.dp))
            lobby.hostId?.let {
                Row(modifier = Modifier.fillMaxWidth(), horizontalArrangement = Arrangement.SpaceBetween) {
                    Text(
                        text = "Game Master ID:",
                        style = MaterialTheme.typography.bodyLarge,
                        color = InkBrown.copy(alpha = 0.8f)
                    )
                    Text(
                        text = "$it",
                        style = MaterialTheme.typography.bodyLarge,
                        color = InkBrown
                    )
                }
                Spacer(modifier = Modifier.height(4.dp))
            }
            lobby.campaignId?.let {
                Row(modifier = Modifier.fillMaxWidth(), horizontalArrangement = Arrangement.SpaceBetween) {
                    Text(
                        text = "Campaign ID:",
                        style = MaterialTheme.typography.bodyLarge,
                        color = InkBrown.copy(alpha = 0.8f)
                    )
                    Text(
                        text = "$it",
                        style = MaterialTheme.typography.bodyLarge,
                        color = InkBrown
                    )
                }
            }
        }
    }
}

@Composable
fun PlayersTabContent(uiState: LobbyDetailUiState, viewModel: LobbyDetailViewModel) {
    Column(
        modifier = Modifier
            .fillMaxSize()
            .padding(16.dp)
            .background(MaterialTheme.colorScheme.background)
    ) {
        if (uiState.players.isEmpty()) {
            Text(
                text = "No players in this lobby yet.",
                style = MaterialTheme.typography.bodyLarge,
                color = InkBrown.copy(alpha = 0.7f),
                modifier = Modifier.align(Alignment.CenterHorizontally)
            )
        } else {
            LazyColumn(verticalArrangement = Arrangement.spacedBy(8.dp)) {
                items(uiState.players) { user ->
                    PlayerItem(user = user)
                }
            }
        }
        uiState.errorMessage?.let { message ->
            Text(
                text = message,
                color = MaterialTheme.colorScheme.error,
                style = MaterialTheme.typography.bodySmall,
                modifier = Modifier.padding(top = 8.dp)
            )
        }
    }
}

@Composable
fun PlayerItem(user: UserDto) {
    Card(
        modifier = Modifier.fillMaxWidth(),
        colors = CardDefaults.cardColors(
            containerColor = MaterialTheme.colorScheme.surfaceVariant,
            contentColor = MaterialTheme.colorScheme.onSurfaceVariant
        )
    ) {
        Column(modifier = Modifier.padding(12.dp)) {
            Text(text = user.login, style = MaterialTheme.typography.titleMedium, fontWeight = FontWeight.Bold)
            Text(text = "ID: ${user.id}", style = MaterialTheme.typography.bodySmall, color = InkBrown.copy(alpha = 0.7f))
        }
    }
}

@Composable
fun ChatTabContent(uiState: LobbyDetailUiState, viewModel: LobbyDetailViewModel) {
    var messageInput by remember { mutableStateOf("") }
    val dateFormatter = remember { SimpleDateFormat("HH:mm", Locale.getDefault()) }

    Column(
        modifier = Modifier.fillMaxSize()
    ) {
        LazyColumn(
            modifier = Modifier
                .weight(1f)
                .padding(horizontal = 16.dp, vertical = 8.dp),
            verticalArrangement = Arrangement.spacedBy(8.dp),
            reverseLayout = true
        ) {
            items(uiState.chatMessages.reversed()) { message ->
                ChatMessageItem(message = message, dateFormatter = dateFormatter)
            }
        }

        Row(
            modifier = Modifier
                .fillMaxWidth()
                .background(MaterialTheme.colorScheme.surface)
                .padding(8.dp),
            verticalAlignment = Alignment.CenterVertically
        ) {
            OutlinedTextField(
                value = messageInput,
                onValueChange = { messageInput = it },
                label = { Text("Enter message") },
                modifier = Modifier.weight(1f),
                singleLine = true,
                keyboardOptions = KeyboardOptions(imeAction = ImeAction.Send),
                colors = OutlinedTextFieldDefaults.colors(
                    focusedBorderColor = AccentGold,
                    unfocusedBorderColor = DarkerParchment,
                    focusedLabelColor = AccentGold,
                    unfocusedLabelColor = InkBrown,
                    cursorColor = InkBrown,
                    focusedTextColor = InkBrown,
                    unfocusedTextColor = InkBrown,
                    unfocusedContainerColor = Parchment,
                    focusedContainerColor = Parchment
                )
            )
            Spacer(modifier = Modifier.width(8.dp))
            IconButton(
                onClick = {
                    viewModel.sendChatMessage(messageInput)
                    messageInput = ""
                },
                enabled = messageInput.isNotBlank(),
                colors = IconButtonDefaults.iconButtonColors(
                    containerColor = AccentGold,
                    contentColor = MaterialTheme.colorScheme.onSecondary
                )
            ) {
                Icon(Icons.Filled.Send, contentDescription = "Send message")
            }
        }
    }
}

@Composable
fun ChatMessageItem(message: MessageDto, dateFormatter: SimpleDateFormat) {
    val isCurrentUser = message.userId == 999
    val alignment = if (isCurrentUser) Alignment.End else Alignment.Start
    val bubbleColor = if (isCurrentUser) MaterialTheme.colorScheme.secondary else DarkerParchment
    val textColor = if (isCurrentUser) MaterialTheme.colorScheme.onSecondary else MaterialTheme.colorScheme.onBackground

    Column(
        modifier = Modifier.fillMaxWidth(),
        horizontalAlignment = alignment
    ) {
        Card(
            modifier = Modifier.widthIn(max = 280.dp),
            colors = CardDefaults.cardColors(
                containerColor = bubbleColor,
                contentColor = textColor
            )
        ) {
            Column(modifier = Modifier.padding(8.dp)) {
                Text(
                    text = "User ID: ${message.userId ?: "Unknown"}",
                    fontWeight = FontWeight.Bold,
                    style = MaterialTheme.typography.labelSmall,
                    color = textColor
                )
                Spacer(modifier = Modifier.height(4.dp))
                Text(
                    text = message.messageContent ?: "",
                    style = MaterialTheme.typography.bodyMedium,
                    color = textColor
                )
                message.creationDate?.let {
                    Text(
                        text = dateFormatter.format(it),
                        style = MaterialTheme.typography.labelSmall,
                        color = textColor.copy(alpha = 0.7f),
                        modifier = Modifier.align(Alignment.End)
                    )
                }
            }
        }
    }
}

@Composable
fun MapTabContent(onEventClick: (eventId: Int) -> Unit) {
    var scale by remember { mutableStateOf(1f) }
    var offsetX by remember { mutableStateOf(0f) }
    var offsetY by remember { mutableStateOf(0f) }

    var imageWidthPx by remember { mutableStateOf(1) }
    var imageHeightPx by remember { mutableStateOf(1) }

    val events = remember {
        listOf(
            EventDto(1, 101, "Goblin Ambush", "A horde of goblins...", "goblin_icon", 0.3, 0.2),
            EventDto(2, 101, "Mysterious Lights", "Strange lights...", "light_icon", 0.7, 0.5),
            EventDto(3, 101, "Missing Artifact", "Ancient amulet stolen...", "artifact_icon", 0.1, 0.8)
        )
    }

    Box(
        modifier = Modifier
            .fillMaxSize()
            .background(MaterialTheme.colorScheme.background)
            .onSizeChanged { size ->
                imageWidthPx = size.width
                imageHeightPx = size.height
            }
            .pointerInput(Unit) {
                detectTransformGestures { _, pan, zoom, _ ->
                    val newScale = (scale * zoom).coerceIn(0.5f, 5f)

                    offsetX += pan.x
                    offsetY += pan.y

                    val scaledContentWidth = imageWidthPx * newScale
                    val scaledContentHeight = imageHeightPx * newScale

                    val maxX = (scaledContentWidth - imageWidthPx) / 2f
                    val maxY = (scaledContentHeight - imageHeightPx) / 2f

                    offsetX = offsetX.coerceIn(-maxX, maxX)
                    offsetY = offsetY.coerceIn(-maxY, maxY)

                    scale = newScale
                }
            },
        contentAlignment = Alignment.Center
    ) {
        Image(
            painter = painterResource(id = R.drawable.game_map),
            contentDescription = "Campaign Map",
            modifier = Modifier
                .fillMaxSize()
                .graphicsLayer(
                    scaleX = scale,
                    scaleY = scale,
                    translationX = offsetX,
                    translationY = offsetY
                )
        )

        events.forEach { event ->
            if (event.xCoordinate != null && event.yCoordinate != null) {
                val buttonX = (event.xCoordinate.toFloat() * imageWidthPx) * scale + offsetX
                val buttonY = (event.yCoordinate.toFloat() * imageHeightPx) * scale + offsetY

                Button(
                    onClick = { onEventClick(event.id) },
                    modifier = Modifier
                        .offset(
                            x = (buttonX - (imageWidthPx * scale / 2f)).dp,
                            y = (buttonY - (imageHeightPx * scale / 2f)).dp
                        )
                        .size(50.dp)
                        .graphicsLayer(
                            scaleX = 1f / scale,
                            scaleY = 1f / scale
                        )
                ) {
                    Text(event.id.toString())
                }
            }
        }
    }
}


@Preview(showBackground = true)
@Composable
fun PreviewLobbyDetailScreenWithTabs() {
    SkuffRollTheme {
        LobbyDetailScreen(onBackClick = {}, onEventClick = {})
    }
}

@Preview(showBackground = true)
@Composable
fun PreviewLobbyDetailCard() {
    SkuffRollTheme {
        val sampleLobby = LobbyDto(
            id = 1,
            name = "Test Lobby Name",
            hostId = 101,
            campaignId = 1001
        )
        LobbyDetailCard(lobby = sampleLobby)
    }
}

@Preview(showBackground = true)
@Composable
fun PreviewPlayerItem() {
    SkuffRollTheme {
        PlayerItem(user = UserDto(id = 1, login = "TestUser", password = "pass", email = "test@example.com", registrationDate = Date()))
    }
}

@Preview(showBackground = true)
@Composable
fun PreviewChatMessageItem() {
    SkuffRollTheme {
        Column {
            ChatMessageItem(
                message = MessageDto(
                    id = 1,
                    userId = 123,
                    creationDate = Date(System.currentTimeMillis() - 120000),
                    messageContent = "Hello, this is a test message from another user."
                ),
                dateFormatter = SimpleDateFormat("HH:mm", Locale.getDefault())
            )
            Spacer(modifier = Modifier.height(8.dp))
            ChatMessageItem(
                message = MessageDto(
                    id = 2,
                    userId = 999,
                    creationDate = Date(System.currentTimeMillis()),
                    messageContent = "And this is my reply!"
                ),
                dateFormatter = SimpleDateFormat("HH:mm", Locale.getDefault())
            )
        }
    }
}

@Preview(showBackground = true)
@Composable
fun PreviewMapTabContent() {
    SkuffRollTheme {
        MapTabContent(onEventClick = {})
    }
}