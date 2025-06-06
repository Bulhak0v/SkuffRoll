package com.example.skuffrollmobileclient.data.model

import com.google.gson.annotations.SerializedName

data class LoginResponseDto(
    @SerializedName("token")
    val token: String,
    @SerializedName("userId") // Змінено на Int
    val userId: Int,
    @SerializedName("nickname")
    val nickname: String,
    @SerializedName("email")
    val email: String? = null,
    @SerializedName("roles")
    val roles: List<String> = emptyList()
)