package com.example.skuffrollmobileclient.data.model

import com.google.gson.annotations.SerializedName
import java.util.Date

data class UserDto(
    @SerializedName("id") val id: Int,
    @SerializedName("login") val login: String,
    @SerializedName("password") val password: String,
    @SerializedName("email") val email: String,
    @SerializedName("registration_date") val registrationDate: Date?
)

