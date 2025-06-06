package com.example.skuffrollmobileclient.data.model

import com.google.gson.annotations.SerializedName
import java.util.Date

data class MessageDto(
    @SerializedName("id") val id: Int,
    @SerializedName("user_id") val userId: Int?,
    @SerializedName("creation_date") val creationDate: Date?,
    @SerializedName("message_content") val messageContent: String?
)
