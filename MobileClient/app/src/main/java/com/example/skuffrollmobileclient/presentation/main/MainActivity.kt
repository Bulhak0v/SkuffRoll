package com.example.skuffrollmobileclient.presentation.main

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Scaffold
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.navigation.NavType
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import androidx.navigation.navArgument
import com.example.skuffrollmobileclient.presentation.auth.login.LoginScreen
import com.example.skuffrollmobileclient.presentation.lobby.detail.LobbyDetailScreen
import com.example.skuffrollmobileclient.presentation.lobby.detail.LOBBY_ID_ARG
import com.example.skuffrollmobileclient.presentation.lobby.list.LobbyListScreen
import com.example.skuffrollmobileclient.presentation.event.detail.EventDetailScreen
import com.example.skuffrollmobileclient.presentation.event.detail.EVENT_ID_ARG
import com.example.skuffrollmobileclient.ui.theme.SkuffRollTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            SkuffRollTheme {
                AppRoot()
            }
        }
    }
}

@Composable
fun AppRoot() {
    val navController = rememberNavController()

    Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
        NavHost(
            navController = navController,
            startDestination = "login",
            modifier = Modifier.padding(innerPadding)
        ) {
            composable("login") {
                LoginScreen(
                    onLoginSuccess = {
                        navController.navigate("lobbyList") {
                            popUpTo("login") { inclusive = true }
                        }
                    }
                )
            }
            composable("lobbyList") {
                LobbyListScreen(
                    onLobbyClick = { lobbyId: Int ->
                        navController.navigate("lobbyDetail/$lobbyId")
                    },
                    onCreateLobbyClick = {
                        println("Navigate to create lobby screen")
                    }
                )
            }
            composable(
                route = "lobbyDetail/{$LOBBY_ID_ARG}",
                arguments = listOf(navArgument(LOBBY_ID_ARG) { type = NavType.IntType })
            ) { backStackEntry ->
                LobbyDetailScreen(
                    onBackClick = { navController.popBackStack() },
                    onEventClick = { eventId: Int ->
                        navController.navigate("eventDetail/$eventId")
                    }
                )
            }
            composable(
                route = "eventDetail/{$EVENT_ID_ARG}",
                arguments = listOf(navArgument(EVENT_ID_ARG) { type = NavType.IntType })
            ) {
                EventDetailScreen(
                    onBackClick = { navController.popBackStack() }
                )
            }
        }
    }
}