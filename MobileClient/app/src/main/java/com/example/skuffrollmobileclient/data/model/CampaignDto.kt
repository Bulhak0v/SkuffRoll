package com.example.skuffrollmobileclient.data.model
import com.google.gson.annotations.SerializedName

data class CampaignDto(
    @SerializedName("id")
    val id: Int,

    @SerializedName("name")
    val name: String,

    @SerializedName("description")
    val description: String?
)
