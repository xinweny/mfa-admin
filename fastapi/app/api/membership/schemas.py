from datetime import date
from pydantic import BaseModel, Field

from app.core.sort import SortOrder
from app.api.membership.constants import MembershipType

class GetMembershipsRequest(BaseModel):
    year_paid: int = Field(ge=1993)
    
    has_paid: bool | None
    query: str | None
    membership_type: MembershipType | None
    since_from: date | None
    since_to: date | None
    is_active: bool | None
    
    sort_start_date: SortOrder | None
