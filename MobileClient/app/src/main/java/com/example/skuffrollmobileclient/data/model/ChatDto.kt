package com.example.skuffrollmobileclient.data.model

import com.google.gson.annotations.SerializedName

data class ChatDto(
    @SerializedName("campaign_id") val campaignId: Int,
    @SerializedName("message_id") val messageId: Int
)
