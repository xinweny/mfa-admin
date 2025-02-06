from datetime import date, datetime
from typing import Optional
from uuid import UUID

from sqlalchemy import ForeignKey, DateTime
from sqlalchemy.sql import func
from sqlalchemy.orm import Mapped, mapped_column, relationship

from app.database import Base
from app.api.membership.models import Membership
from app.api.board_member.models import BoardMember

class Member(Base):
    __tablename__ = 'members'
  
    id: Mapped[UUID] = mapped_column(primary_key=True)
    
    first_name: Mapped[str]
    last_name: Mapped[str]
    email: Mapped[str]
    phone_number: Mapped[Optional[str]]
    joined_date: Mapped[Optional[date]]
    
    # pylint: disable=not-callable
    created_at: Mapped[datetime] = mapped_column(DateTime(timezone=True), server_default=func.now())
    updated_at: Mapped[Optional[datetime]] = mapped_column(DateTime(timezone=True), onupdate=datetime.now)
    
    membership_id: Mapped[UUID] = mapped_column(ForeignKey('memberships.id'))
    membership: Mapped[Membership] = relationship(Membership, back_populates='children')
    board_positions: Mapped[BoardMember] = relationship(BoardMember, back_populates='children')