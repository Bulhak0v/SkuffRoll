package com.example.skuffrollmobileclient.ui.theme

import android.app.Activity
import android.os.Build
import androidx.compose.foundation.isSystemInDarkTheme
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.darkColorScheme
import androidx.compose.material3.*
import androidx.compose.material3.dynamicDarkColorScheme
import androidx.compose.material3.dynamicLightColorScheme
import androidx.compose.material3.lightColorScheme
import androidx.compose.runtime.Composable
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.graphics.Color

private val SkuffRollColorScheme = lightColorScheme(
    primary = Parchment,
    onPrimary = InkBrown,
    primaryContainer = DarkerParchment,
    onPrimaryContainer = InkBrown,
    secondary = AccentGold,
    onSecondary = White,
    tertiary = Parchment,
    onTertiary = InkBrown,
    background = Parchment,
    onBackground = InkBrown,
    surface = DarkerParchment,
    onSurface = InkBrown,
    error = ErrorRed,
    onError = White
)

private val DarkColorScheme = darkColorScheme(
    primary = InkBrown,
    onPrimary = Color.White,
    background = Color(0xFF2B2B2B),
    surface = Color(0xFF3E3E3E),
    onSurface = Color.White
)

@Composable
fun SkuffRollTheme(
    darkTheme: Boolean = isSystemInDarkTheme(),
    content: @Composable () -> Unit
) {
    val colors = SkuffRollColorScheme

    MaterialTheme(
        colorScheme = colors,
        typography = Typography,
        content = content
    )
}