package com.example.skuffrollmobileclient.presentation.auth.login

import androidx.compose.foundation.background // <-- Possibly used, adding it
import androidx.compose.foundation.layout.*
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment // <-- Possibly used, adding it
import androidx.compose.ui.Modifier
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.tooling.preview.Preview // <-- Possibly used, adding it
import androidx.compose.ui.unit.dp
// --- Adding required imports for styling if not already present ---
import com.example.skuffrollmobileclient.ui.theme.SkuffRollTheme
import com.example.skuffrollmobileclient.ui.theme.InkBrown
import com.example.skuffrollmobileclient.ui.theme.Parchment
import com.example.skuffrollmobileclient.ui.theme.DarkerParchment
import com.example.skuffrollmobileclient.ui.theme.AccentGold
import com.example.skuffrollmobileclient.ui.theme.White
import com.example.skuffrollmobileclient.ui.theme.ErrorRed
// --- End of added imports ---

@OptIn(ExperimentalMaterial3Api::class) // Added because OutlinedTextFieldDefaults.colors is used
@Composable
fun LoginScreen(
    modifier: Modifier = Modifier,
    // Changed 'onLoginClick' to 'onLoginSuccess' to match MainActivity
    onLoginSuccess: () -> Unit
) {
    var email by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }

    // Using Scaffold and our theme for a consistent appearance
    Scaffold(modifier = modifier.fillMaxSize()) { paddingValues ->
        Column(
            modifier = Modifier
                .fillMaxSize()
                .padding(paddingValues) // Add padding from Scaffold
                .background(MaterialTheme.colorScheme.background) // Use theme background color
                .padding(16.dp),
            verticalArrangement = Arrangement.Center,
            horizontalAlignment = Alignment.CenterHorizontally // Center alignment
        ) {
            Text(
                text = "Login",
                style = MaterialTheme.typography.headlineMedium,
                color = MaterialTheme.colorScheme.onBackground // Text color from theme
            )
            Spacer(modifier = Modifier.height(16.dp))
            OutlinedTextField(
                value = email,
                onValueChange = { email = it },
                label = { Text("Email") },
                singleLine = true,
                modifier = Modifier.fillMaxWidth(),
                colors = OutlinedTextFieldDefaults.colors( // Custom colors for input field
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
            Spacer(modifier = Modifier.height(8.dp))
            OutlinedTextField(
                value = password,
                onValueChange = { password = it },
                label = { Text("Password") },
                singleLine = true,
                modifier = Modifier.fillMaxWidth(),
                visualTransformation = PasswordVisualTransformation(),
                colors = OutlinedTextFieldDefaults.colors( // Custom colors for input field
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
            Spacer(modifier = Modifier.height(16.dp))
            Button(
                // Call onLoginSuccess when clicked
                onClick = { onLoginSuccess() },
                modifier = Modifier.fillMaxWidth(),
                colors = ButtonDefaults.buttonColors(
                    containerColor = AccentGold,
                    contentColor = White
                )
            ) {
                Text("Login", color = MaterialTheme.colorScheme.onSecondary) // Button text color
            }
        }
    }
}

// Preview for LoginScreen
@Preview(showBackground = true)
@Composable
fun PreviewLoginScreen() {
    SkuffRollTheme {
        LoginScreen(onLoginSuccess = {})
    }
}
