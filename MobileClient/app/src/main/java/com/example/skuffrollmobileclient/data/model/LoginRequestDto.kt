package com.example.skuffrollmobileclient.data.model

import com.google.gson.annotations.SerializedName

data class LoginRequestDto(
    @SerializedName("username")
    val username: String,
    @SerializedName("password")
    val password: String
)